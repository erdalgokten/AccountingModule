using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Events
{
    public interface IEventReaction
    {
        string ID { get; }
        Dictionary<string, object> TakeReaction(IDataSourceStore dsStore);
    }
}
