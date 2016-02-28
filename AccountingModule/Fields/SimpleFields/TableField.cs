using AccountingModule.DataSource;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.SimpleFields
{
    class TableField : SimpleField
    {
        public string FieldType { private set; get; }
        public string FieldName { private set; get; }
        public object FieldValue { set; get; }

        public TableField(string fieldType, string fieldName)
        {
            this.FieldType = fieldType;
            this.FieldName = fieldName;
        }

        public override object GetSimpleFieldValue(IDataSourceStore dsStore)
        {
            DataTypes dataType;
            if (!Enum.TryParse<DataTypes>(this.FieldType, out dataType))
            {
                throw new AccountingModuleException("Data type is not supported. Data type was: {0}. Field name was: {1}", this.FieldType, this.FieldName ?? string.Empty);
            }

            IDataSource ds = dsStore.GetDataSource(DataSources.Table);

            switch (dataType)
            {
                case DataTypes.Decimal: return ds.GetValue<Decimal>(this.FieldName);
                case DataTypes.Int32: return ds.GetValue<Int32>(this.FieldName);
                case DataTypes.String: return ds.GetValue<String>(this.FieldName);
                case DataTypes.DateTime: return ds.GetValue<DateTime>(this.FieldName);
                case DataTypes.TimeSpan: return ds.GetValue<DateTime>(this.FieldName).TimeOfDay;
                default: throw new AccountingModuleException("Data type is not supported. Data type was: {0}. Field name was: {1}", dataType.ToString(), this.FieldName ?? string.Empty);
            }
        }
    }
}
