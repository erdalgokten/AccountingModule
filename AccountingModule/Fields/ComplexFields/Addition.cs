using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields.ComplexFields
{
    class Addition : ComplexField
    {
        public override object GetComplexFieldValue(IDataSourceStore dsStore)
        {
            object temp = null;
            foreach (var fld in this.innerFields)
            {
                if (temp == null)
                    temp = fld.GetValue(dsStore);
                else
                    temp = this.Add(temp, fld.GetValue(dsStore));
            }
            return temp;
        }
    }
}
