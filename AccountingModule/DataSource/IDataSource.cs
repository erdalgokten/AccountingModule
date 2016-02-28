using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.DataSource
{
    public interface IDataSource
    {
        DataSources SourceType { get; }
        T GetValue<T>(string fieldName);
    }
}
