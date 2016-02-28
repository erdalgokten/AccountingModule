using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.ComplexFields
{
    abstract class ComplexField : Field
    {
        protected List<Field> innerFields;

        public ComplexField()
        {
            this.innerFields = new List<Field>();
        }

        public ComplexField AddField(Field field)
        {
            this.innerFields.Add(field);
            return this;
        }

        public abstract object GetComplexFieldValue(IDataSourceStore dsStore);

        public override object GetValue(IDataSourceStore dsStore)
        {
            return this.GetComplexFieldValue(dsStore);
        }
    }
}
