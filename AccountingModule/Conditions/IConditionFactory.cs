using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.Conditions.SimpleConditions;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions
{
    interface IConditionFactory
    {
        ComplexCondition CreateAndCondition();
        ComplexCondition CreateOrCondition();
        SimpleCondition CreateIsEqualCondition(Field sourceField, Field targetField);
        SimpleCondition CreateIsGreaterCondition(Field sourceField, Field targetField);
        SimpleCondition CreateIsLessCondition(Field sourceField, Field targetField);
        SimpleCondition CreateIsNotEqualCondition(Field sourceField, Field targetField);
        SimpleCondition CreateIsGreaterOrEqualCondition(Field sourceField, Field targetField);
        SimpleCondition CreateIsLessOrEqualCondition(Field sourceField, Field targetField);
    }
}
