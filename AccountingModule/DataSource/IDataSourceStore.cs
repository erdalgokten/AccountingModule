using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.DataSource
{
    public enum DataSources
    { 
        Table,
        Legacy
    }

    public interface IDataSourceStore
    {
        IDataSourceStore AddDataSource(IDataSource dataSource);
        IDataSource GetDataSource(DataSources sourceType);
        void ClearAll();
    }
}
