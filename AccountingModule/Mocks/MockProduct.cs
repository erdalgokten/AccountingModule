using AccountingModule.DataSource;
using AccountingModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    public sealed class MockProduct : ProductBase
    {
        public MockProduct(string productName, List<IEventDefinition> eventDefinitions, List<IEventReaction> eventReactions)
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
