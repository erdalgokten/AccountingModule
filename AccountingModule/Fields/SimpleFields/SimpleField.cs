using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.SimpleFields
{
    enum DataTypes
    { 
        Decimal,
        Int32,
        String,
        DateTime,
        TimeSpan,
        Special
    }

    abstract class SimpleField : Field
    {
        public abstract object GetSimpleFieldValue(IDataSourceStore dsStore);

        public override object GetValue(IDataSourceStore dsStore)
        {
            return this.GetSimpleFieldValue(dsStore);
        }
    }
}
