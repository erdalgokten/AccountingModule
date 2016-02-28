using AccountingModule.Conditions;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Farms
{
    interface IFactoryFarm
    {
        IConditionFactory ConditionFactory { get; }
        IFieldFactory FieldFactory { get; }
    }
}
