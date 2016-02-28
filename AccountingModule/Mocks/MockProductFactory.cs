using AccountingModule.Events;
using AccountingModule.Farms;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    public class MockProductFactory : IProductFactory
    {
        private const string PRODUCT_METADATA_FILE = "ProductMetadata.xsd";

        public ProductBase CreateProduct(string productName, string xmlPath)
        {
            XmlHelper xh = new XmlHelper();
            string xsdPath = Path.Combine(Environment.CurrentDirectory, PRODUCT_METADATA_FILE);
            xh.ValidateXml(xmlPath, xsdPath);

            IFactoryFarm ff = new MockFactoryFarm();
            List<IEventReaction> eventReactions = new List<IEventReaction>();
            Dictionary<string, IEventReaction> eventReactionsDict = new Dictionary<string, IEventReaction>();
            foreach (var evRec in xh.DigestEventReactions(xmlPath, ff))
            {
                eventReactions.Add(evRec);
                eventReactionsDict.Add(evRec.ID, evRec);
            }
            List<IEventDefinition> eventDefinitions = xh.DigestEventDefinitions(xmlPath, ff, eventReactionsDict).ToList<IEventDefinition>();

            ProductBase product = new MockProduct(productName, eventDefinitions, eventReactions);

            return product;
        }
    }
}
