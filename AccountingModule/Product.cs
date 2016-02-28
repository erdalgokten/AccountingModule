using AccountingModule.Conditions;
using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.Conditions.SimpleConditions;
using AccountingModule.DataSource;
using AccountingModule.Events;
using AccountingModule.Farms;
using AccountingModule.Fields;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Fields.SimpleFields;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace AccountingModule
{
    public sealed class Product : ProductBase
    {
        public Product(string productName, List<IEventDefinition> eventDefinitions, List<IEventReaction> eventReactions)
            : base(productName, eventDefinitions, eventReactions)
        { }

        public override IEnumerable<IEventDefinition> GetHoldEvents(IDataSourceStore dsStore)
        {
            foreach (var evDef in this.eventDefinitions)
            {
                if (evDef.IsHold(dsStore))
                {
                    yield return evDef;
                }
            }
        }

        public override IEnumerable<Tuple<IEventReaction, Dictionary<string, object>>> TakeReactionsFor(IEventDefinition eventDefinition, IDataSourceStore dsStore)
        {
            foreach (var evRec in eventDefinition.EventReactions)
            {
                yield return Tuple.Create<IEventReaction, Dictionary<string, object>>(evRec, evRec.TakeReaction(dsStore));
            }
        }
    }
}
