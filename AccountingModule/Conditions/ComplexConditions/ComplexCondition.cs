using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions.ComplexConditions
{
    abstract class ComplexCondition : ICondition
    {
        protected List<ICondition> innerConditions;

        public ComplexCondition()
        {
            this.innerConditions = new List<ICondition>();
        }

        public ComplexCondition AddCondition(ICondition condition)
        {
            this.innerConditions.Add(condition);
            return this;
        }

        public abstract bool IsComplexConditionHold(IDataSourceStore dsStore);

        public bool IsHold(IDataSourceStore dsStore)
        {
            return this.IsComplexConditionHold(dsStore);
        }
    }
}
