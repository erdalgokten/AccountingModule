using AccountingModule.Conditions;
using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.Events;
using AccountingModule.Farms;
using AccountingModule.Fields;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace AccountingModule.Misc
{
    class XmlHelper
    {
        public void ValidateXml(string xmlPath, string xsdPath)
        {
            var settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdPath); // no need for targetNamespace since it is only one
            settings.ValidationType = ValidationType.Schema;

            var reader = XmlReader.Create(xmlPath, settings);
            var document = new XmlDocument();
            document.Load(reader);

            var eventHandler = new ValidationEventHandler(ValidationEventHandler);

            document.Validate(eventHandler);
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new AccountingModuleException(e.Exception, "Xml file is invalid. Error: {0}", e.Message);
                case XmlSeverityType.Warning:
                    throw new AccountingModuleException(e.Exception, "Xml file is invalid. Warning: {0}", e.Message);
            }
        }

        public IEnumerable<IEventReaction> DigestEventReactions(string xmlPath, IFactoryFarm factoryFarm)
        {
            if (string.IsNullOrWhiteSpace(xmlPath))
            {
                throw new AccountingModuleException("Xml file path should be a valid one. Xml path was: {0}", xmlPath);
            }
            if (factoryFarm == null)
            {
                throw new AccountingModuleException("Factory farm should be set in order to digest the xml file");
            }

            XPathNavigator nav;
            XPathDocument doc;

            doc = new XPathDocument(xmlPath);
            nav = doc.CreateNavigator();
            nav.MoveToRoot();

            nav.MoveToFirstChild(); // product
            nav.MoveToFirstChild(); // productName
            nav.MoveToNext(); // eventDefinitions
            nav.MoveToNext(); // eventReactions

            nav.MoveToFirstChild(); // eventReaction
            do
            {
                yield return this.DigestEventReaction(nav.Clone(), factoryFarm);
            } while (nav.MoveToNext()); // eventReaction
        }

        public IEnumerable<IEventDefinition> DigestEventDefinitions(string xmlPath, IFactoryFarm factoryFarm, Dictionary<string, IEventReaction> eventReactions)
        {
            if (string.IsNullOrWhiteSpace(xmlPath))
            {
                throw new AccountingModuleException("Xml file path should be a valid one. Xml path was: {0}", xmlPath);
            }
            if (factoryFarm == null)
            {
                throw new AccountingModuleException("Factory farm should be set in order to digest the xml file");
            }
            if (eventReactions == null || eventReactions.Count == 0)
            {
                throw new AccountingModuleException("There must be at least one eventReaction to digest event definitions");
            }

            XPathNavigator nav;
            XPathDocument doc;

            doc = new XPathDocument(xmlPath);
            nav = doc.CreateNavigator();
            nav.MoveToRoot();

            nav.MoveToFirstChild(); // product
            nav.MoveToFirstChild(); // productName
            nav.MoveToNext(); // eventDefinitions

            nav.MoveToFirstChild(); // eventDefinition
            do
            {
                yield return this.DigestEventDefinition(nav.Clone(), factoryFarm, eventReactions); // eventDefinition
            } while (nav.MoveToNext()); // eventDefinition
        }

        private EventReaction DigestEventReaction(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            var id = nav.GetAttribute("id", string.Empty); // eventReaction.id
            var reactionType = nav.GetAttribute("reactionType", string.Empty); // eventReaction.reactionType

            nav.MoveToFirstChild(); // fieldMatch

            List<FieldMatch> fieldMatches = new List<FieldMatch>();
            do
            {
                fieldMatches.Add(this.DigestFieldMatch(nav.Clone(), factoryFarm));
            } while (nav.MoveToNext());

            var evRec = new EventReaction(id, reactionType, fieldMatches);

            return evRec;
        }

        private FieldMatch DigestFieldMatch(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            nav.MoveToFirstChild(); // sourceField
            var sourceField = DigestField(nav.Clone(), factoryFarm);

            nav.MoveToNext(); // targetField
            var targetField = DigestField(nav.Clone(), factoryFarm);

            var fieldMatch = new FieldMatch(sourceField, targetField);

            return fieldMatch;
        }

        private EventDefinition DigestEventDefinition(XPathNavigator nav, IFactoryFarm factoryFarm, Dictionary<string, IEventReaction> eventReactions)
        {
            var id = nav.GetAttribute("id", string.Empty); // eventDefinition.id
            var isOnline = Convert.ToBoolean(nav.GetAttribute("isOnline", string.Empty)); // eventDefinition.isOnline
            var reactionIds = nav.GetAttribute("reactionIds", string.Empty).Split(' '); // eventDefinition.reactionIds

            List<IEventReaction> reactions = new List<IEventReaction>();
            foreach (var reactionId in reactionIds)
            {
                if (!eventReactions.ContainsKey(reactionId))
                {
                    throw new AccountingModuleException("Referenced reaction could not be found in the xml. Reaction was: {0}", reactionId);
                }

                var evRec = eventReactions[reactionId];
                reactions.Add(evRec);
            }

            nav.MoveToFirstChild();

            var condition = this.DigestCondition(nav.Clone(), factoryFarm);
            var evDef = new EventDefinition(id, isOnline, condition, reactions);

            return evDef;
        }

        private ICondition DigestCondition(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            ConditionTypes conditionType;
            if (!Enum.TryParse<ConditionTypes>(nav.Name, out conditionType))
            {
                throw new AccountingModuleException("Condition type is not supported. Condition type was: {0}", nav.Name);
            }

            switch (conditionType)
            {
                case ConditionTypes.and:
                case ConditionTypes.or:
                    {
                        ComplexCondition complexCondition = null;
                        switch (conditionType)
                        {
                            case ConditionTypes.and: complexCondition = factoryFarm.ConditionFactory.CreateAndCondition(); break;
                            case ConditionTypes.or: complexCondition = factoryFarm.ConditionFactory.CreateOrCondition(); break;
                        }

                        nav.MoveToFirstChild();

                        do
                        {
                            complexCondition.AddCondition(DigestCondition(nav.Clone(), factoryFarm));
                        } while (nav.MoveToNext());

                        return complexCondition;
                    }
                case ConditionTypes.isEqual:
                case ConditionTypes.isGreater:
                case ConditionTypes.isLess:
                case ConditionTypes.isNotEqual:
                case ConditionTypes.isGreaterOrEqual:
                case ConditionTypes.isLessOrEqual:
                    {
                        ICondition simpleCondition = null;

                        nav.MoveToFirstChild(); // sourceField
                        var sourceField = DigestField(nav.Clone(), factoryFarm);

                        nav.MoveToNext(); // targetField
                        var targetField = DigestField(nav.Clone(), factoryFarm);

                        switch (conditionType)
                        {
                            case ConditionTypes.isEqual: simpleCondition = factoryFarm.ConditionFactory.CreateIsEqualCondition(sourceField, targetField); break;
                            case ConditionTypes.isGreater: simpleCondition = factoryFarm.ConditionFactory.CreateIsGreaterCondition(sourceField, targetField); break;
                            case ConditionTypes.isLess: simpleCondition = factoryFarm.ConditionFactory.CreateIsLessCondition(sourceField, targetField); break;
                            case ConditionTypes.isNotEqual: simpleCondition = factoryFarm.ConditionFactory.CreateIsNotEqualCondition(sourceField, targetField); break;
                            case ConditionTypes.isGreaterOrEqual: simpleCondition = factoryFarm.ConditionFactory.CreateIsGreaterOrEqualCondition(sourceField, targetField); break;
                            case ConditionTypes.isLessOrEqual: simpleCondition = factoryFarm.ConditionFactory.CreateIsLessOrEqualCondition(sourceField, targetField); break;
                        }

                        return simpleCondition;
                    }
                default: throw new AccountingModuleException("Condition type is not supported. Condition type was: {0}", conditionType.ToString());
            }
        }

        private Field DigestField(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            nav.MoveToFirstChild(); // literalField, tableField, addition, multiplication

            FieldTypes fieldType;
            if (!Enum.TryParse<FieldTypes>(nav.Name, out fieldType))
            {
                throw new AccountingModuleException("Field type is not supported. Field type was: {0}", nav.Name);
            }

            switch (fieldType)
            {
                case FieldTypes.literalField: return DigestLiteralField(nav.Clone(), factoryFarm);
                case FieldTypes.tableField: return DigestTableField(nav.Clone(), factoryFarm);
                case FieldTypes.specialField: return DigestSpecialField(nav.Clone(), factoryFarm);
                case FieldTypes.addition:
                case FieldTypes.multiplication:
                    {
                        ComplexField complexField = null;
                        switch (fieldType)
                        {
                            case FieldTypes.addition: complexField = factoryFarm.FieldFactory.CreateAdditionField(); break;
                            case FieldTypes.multiplication: complexField = factoryFarm.FieldFactory.CreateMultiplicationField(); break;
                        }

                        nav.MoveToFirstChild(); // literalField, tableField, addition, multiplication

                        do
                        {
                            complexField.AddField(DigestField(nav.Clone(), factoryFarm));
                        } while (nav.MoveToNext());

                        return complexField;
                    }
                default: throw new AccountingModuleException("Field type is not supported. Field type was: {0}", fieldType.ToString());
            }
        }

        private Field DigestLiteralField(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            string fieldType = nav.GetAttribute("fieldType", string.Empty);
            string fieldName = nav.GetAttribute("fieldName", string.Empty);
            string fieldValue = nav.GetAttribute("fieldValue", string.Empty);

            return factoryFarm.FieldFactory.CreateLiteralField(fieldType, fieldName, fieldValue);
        }

        private Field DigestTableField(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            string fieldType = nav.GetAttribute("fieldType", string.Empty);
            string fieldName = nav.GetAttribute("fieldName", string.Empty);

            return factoryFarm.FieldFactory.CreateTableField(fieldType, fieldName);
        }

        private Field DigestSpecialField(XPathNavigator nav, IFactoryFarm factoryFarm)
        {
            string fieldName = nav.GetAttribute("fieldName", string.Empty);
            string fieldValue = nav.GetAttribute("fieldValue", string.Empty);

            return factoryFarm.FieldFactory.CreateSpecialField(fieldName, fieldValue);
        }
    }
}
