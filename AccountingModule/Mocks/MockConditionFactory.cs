using AccountingModule.Conditions;
using AccountingModule.Conditions.ComplexConditions;
using AccountingModule.Conditions.SimpleConditions;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    class MockConditionFactory : IConditionFactory
    {
        public ComplexCondition CreateAndCondition()
        {
            return new MockAnd();
        }

        public ComplexCondition CreateOrCondition()
        {
            return new MockOr();
        }

        public SimpleCondition CreateIsEqualCondition(Field sourceField, Field targetField)
        {
            return new IsEqual(sourceField, targetField);
        }

        public SimpleCondition CreateIsGreaterCondition(Field sourceField, Field targetField)
        {
            return new IsGreater(sourceField, targetField);
        }

        public SimpleCondition CreateIsLessCondition(Field sourceField, Field targetField)
        {
            return new IsLess(sourceField, targetField);
        }

        public SimpleCondition CreateIsNotEqualCondition(Field sourceField, Field targetField)
        {
            return new IsNotEqual(sourceField, targetField);
        }

        public SimpleCondition CreateIsGreaterOrEqualCondition(Field sourceField, Field targetField)
        {
            return new IsGreaterOrEqual(sourceField, targetField);
        }

        public SimpleCondition CreateIsLessOrEqualCondition(Field sourceField, Field targetField)
        {
            return new IsLessOrEqual(sourceField, targetField);
        }
    }
}
