using AccountingModule.DataSource;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.SimpleFields
{
    class LiteralField : SimpleField
    {
        public string FieldType { private set; get; }
        public string FieldName { private set; get; }
        public string FieldValue { private set; get; }

        public LiteralField(string fieldType, string fieldName, string fieldValue)
        {
            this.FieldType = fieldType;
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;
        }

        public override object GetSimpleFieldValue(IDataSourceStore dsStore)
        {
            DataTypes dataType;
            if (!Enum.TryParse<DataTypes>(this.FieldType, out dataType))
            {
                throw new AccountingModuleException("Data tye is not supported. Data type was: {0}. Field name was: {1}", this.FieldType, this.FieldName ?? string.Empty);
            }

            switch (dataType)
            {
                case DataTypes.Decimal: return Convert.ToDecimal(this.FieldValue);
                case DataTypes.Int32: return Convert.ToInt32(this.FieldValue);
                case DataTypes.String: return Convert.ToString(this.FieldValue);
                case DataTypes.DateTime: return Convert.ToDateTime(this.FieldValue);
                case DataTypes.TimeSpan: return Convert.ToDateTime(this.FieldValue).TimeOfDay;
                default: throw new AccountingModuleException("Data type is not supported. Data type was: {0}. Field name was: {1}", dataType.ToString(), this.FieldName ?? string.Empty);
            }
        }
    }
}
