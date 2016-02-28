using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.DataSource
{
    public class TableDataSource : IDataSource
    {
        private Dictionary<string, object> row;

        public TableDataSource(Dictionary<string, object> row)
        {
            this.row = row;
        }

        public DataSources SourceType
        {
            get { return DataSources.Table; }
        }

        public T GetValue<T>(string fieldName)
        {
            if (!row.ContainsKey(fieldName))
            {
                throw new AccountingModuleException("Field name not found in the table row. Field name was: {0}", fieldName);
            }

            bool isEmpty = row[fieldName] == null || row[fieldName] == DBNull.Value;
            object value = isEmpty ? default(T) : row[fieldName];

            T converted = (T)Convert.ChangeType(value, typeof(T));
            return converted;
        }
    }
}
