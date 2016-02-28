using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Events
{
    public interface IEventDefinition
    {
        bool IsHold(IDataSourceStore dsStore);
        IEnumerable<IEventReaction> EventReactions { get; }
    }
}
