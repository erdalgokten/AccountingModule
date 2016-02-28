using AccountingModule.Conditions;
using AccountingModule.Farms;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    class MockFactoryFarm : IFactoryFarm
    {
        private IConditionFactory cf = new MockConditionFactory();
        private IFieldFactory ff = new MockFieldFactory();

        public IConditionFactory ConditionFactory
        {
            get { return this.cf; }
        }

        public IFieldFactory FieldFactory
        {
            get { return this.ff; }
        }
    }
}
