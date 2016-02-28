using AccountingModule.DataSource;
using AccountingModule.Fields;
using AccountingModule.Fields.SimpleFields;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Events
{
    class EventReaction : IEventReaction
    {
        public string ID { private set; get; }
        public string ReactionType { private set; get; }
        private List<FieldMatch> fieldMatches;

        public EventReaction(string id, string reactionType, List<FieldMatch> fieldMatches)
        {
            this.ID = id;
            this.ReactionType = reactionType;
            this.fieldMatches = fieldMatches;
        }

        public Dictionary<string, object> TakeReaction(IDataSourceStore dsStore)
        {
            Dictionary<string, object> fields = new Dictionary<string, object>();

            foreach (var fieldMatch in this.fieldMatches)
            {
                if (!(fieldMatch.TargetField is TableField))
                {
                    throw new AccountingModuleException("Target field must be of table field type. Field type was: {0}. Field name was: {1}", fieldMatch.TargetField.GetType().FullName);
                }

                object value = fieldMatch.SourceField.GetValue(dsStore);
                string targetFieldName = ((TableField)fieldMatch.TargetField).FieldName;
                fields.Add(targetFieldName, value);
            }
            return fields;
        }
    }
}
