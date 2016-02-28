using AccountingModule.Conditions;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Farms
{
    class FactoryFarm : IFactoryFarm
    {
        private IConditionFactory cf = new ConditionFactory();
        private IFieldFactory ff = new FieldFactory();

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
