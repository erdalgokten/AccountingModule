using AccountingModule.DataSource;
using AccountingModule.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields
{
    enum FieldTypes
    { 
        literalField,
        tableField,
        specialField,
        addition,
        multiplication
    }

    abstract class Field
    {
        public abstract object GetValue(IDataSourceStore dsStore);

        public bool IsEqualTo(Field another, IDataSourceStore dsStore)
        {
            return CustomMathOps.IsEqualTo(this.GetValue(dsStore), another.GetValue(dsStore));
        }

        public bool IsGreaterThan(Field another, IDataSourceStore dsStore)
        {
            return CustomMathOps.IsGreaterThan(this.GetValue(dsStore), another.GetValue(dsStore));
        }

        public bool IsLessThan(Field another, IDataSourceStore dsStore)
        {
            return CustomMathOps.IsLessThan(this.GetValue(dsStore), another.GetValue(dsStore));
        }

        protected object Add(object first, object second)
        {
            return CustomMathOps.Add(first, second);
        }

        protected object Multiply(object first, object second)
        {
            return CustomMathOps.Multiply(first, second);
        }
    }
}
