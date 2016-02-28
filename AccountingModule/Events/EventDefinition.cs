using AccountingModule.Conditions;
using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Events
{
    class EventDefinition : IEventDefinition
    {
        public string ID { private set; get; }
        public bool IsOnline { private set; get; }
        public ICondition Condition { private set; get; }
        private List<IEventReaction> reactions;

        public EventDefinition(string id, bool isOnline, ICondition condition, List<IEventReaction> reactions)
        {
            this.ID = id;
            this.IsOnline = isOnline;
            this.Condition = condition;
            this.reactions = reactions;
        }

        public bool IsHold(IDataSourceStore dsStore)
        {
            return this.Condition.IsHold(dsStore);
        }

        public IEnumerable<IEventReaction> EventReactions
        {
            get { return this.reactions; }
        }
    }
}
