using AccountingModule.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions
{
    enum ConditionTypes
    { 
        and,
        or,
        isEqual,
        isGreater,
        isLess,
        isNotEqual,
        isGreaterOrEqual,
        isLessOrEqual
    }

    interface ICondition
    {
        bool IsHold(IDataSourceStore dsStore);
    }
}
