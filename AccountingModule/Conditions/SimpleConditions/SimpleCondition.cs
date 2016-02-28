using AccountingModule.DataSource;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions.SimpleConditions
{
    abstract class SimpleCondition : ICondition
    {
        protected Field sourceField;
        protected Field targetField;

        public SimpleCondition(Field sourceField, Field targetField)
        {
            this.sourceField = sourceField;
            this.targetField = targetField;
        }   

        public abstract bool IsSimpleConditonHold(IDataSourceStore dsStore);

        public bool IsHold(IDataSourceStore dsStore)
        {
            return this.IsSimpleConditonHold(dsStore);
        }
    }
}
