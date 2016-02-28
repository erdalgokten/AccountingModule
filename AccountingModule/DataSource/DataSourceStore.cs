using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.DataSource
{
    public class DataSourceStore : IDataSourceStore
    {
        private Dictionary<DataSources, IDataSource> dataSources;

        public DataSourceStore()
        {
            this.dataSources = new Dictionary<DataSources, IDataSource>();
        }

        public IDataSourceStore AddDataSource(IDataSource dataSource)
        {
            if (this.dataSources.ContainsKey(dataSource.SourceType))
            {
                throw new AccountingModuleException("Data source was already added. Data source: {0}", dataSource.SourceType);
            }

            this.dataSources.Add(dataSource.SourceType, dataSource);
            return this;
        }

        public void ClearAll()
        {
            this.dataSources.Clear();
        }

        public IDataSource GetDataSource(DataSources sourceType)
        {
            if (!this.dataSources.ContainsKey(sourceType))
            {
                throw new AccountingModuleException("Dat source not found. Data source: {0}", sourceType.ToString());
            }

            return this.dataSources[sourceType];
        }
    }
}
