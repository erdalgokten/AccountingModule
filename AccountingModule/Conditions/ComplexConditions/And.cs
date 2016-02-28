using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions.ComplexConditions
{
    class And : ComplexCondition
    {
        public override bool IsComplexConditionHold(IDataSourceStore dsStore)
        {
            foreach (var condition in this.innerConditions)
            {
                if (!condition.IsHold(dsStore))
                    return false;
            }
            return true;
        }
    }
}
