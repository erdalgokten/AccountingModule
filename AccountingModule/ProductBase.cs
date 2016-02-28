using AccountingModule.Conditions;
using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.DataSource;
using AccountingModule.Events;
using AccountingModule.Farms;
using AccountingModule.Fields;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;

namespace AccountingModule
{
    public abstract class ProductBase
    {
        public string ProductName { private set; get; }
        protected List<IEventDefinition> eventDefinitions;
        private List<IEventReaction> eventReactions;

        public ProductBase(string productName, List<IEventDefinition> eventDefinitions, List<IEventReaction> eventReactions)
        {
            this.ProductName = productName;
            this.eventDefinitions = eventDefinitions;
            this.eventReactions = eventReactions;
        }

        public abstract IEnumerable<IEventDefinition> GetHoldEvents(IDataSourceStore dsStore);
        public abstract IEnumerable<Tuple<IEventReaction, Dictionary<string, object>>> TakeReactionsFor(IEventDefinition eventDefinition, IDataSourceStore dsStore);
    }
}
