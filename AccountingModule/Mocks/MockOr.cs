using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    class MockOr : ComplexCondition
    {
        public override bool IsComplexConditionHold(IDataSourceStore dsStore)
        {
            foreach (var condition in this.innerConditions)
            {
                condition.IsHold(dsStore); // since we want every condition to be exhausted we do not use short-circuit evaluation
            }
            return true;
        }
    }
}
