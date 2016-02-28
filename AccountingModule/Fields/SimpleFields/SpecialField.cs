using AccountingModule.DataSource;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.SimpleFields
{
    enum SpecialFieldValues
    { 
        CurrentDate,
        CurrentTime,
        CurrentDateTime
    }

    class SpecialField : SimpleField
    {
        public string FieldName { private set; get; }
        public string FieldValue { private set; get; }

        public SpecialField(string fieldName, string fieldValue)
        {
            this.FieldName = fieldName;
            this.FieldValue = fieldValue;
        }

        public override object GetSimpleFieldValue(IDataSourceStore dsStore)
        {
            SpecialFieldValues specialFieldValue;
            if (!Enum.TryParse<SpecialFieldValues>(this.FieldValue, out specialFieldValue))
            {
                throw new AccountingModuleException("Special field value is not supported. Value was: {0}. Field name was: {1}", this.FieldValue, this.FieldName ?? string.Empty);
            }

            switch (specialFieldValue)
            {
                case SpecialFieldValues.CurrentDate: return DateTime.Now.Date;
                case SpecialFieldValues.CurrentTime: return DateTime.Now.TimeOfDay;
                case SpecialFieldValues.CurrentDateTime: return DateTime.Now;
                default: throw new AccountingModuleException("Special field value is not supported. Value was: {0}. Field name was: {1}", specialFieldValue.ToString(), this.FieldName ?? string.Empty);
            }
        }
    }
}
