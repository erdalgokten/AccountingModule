﻿using AccountingModule.DataSource;
using AccountingModule.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Conditions.SimpleConditions
{
    class IsEqual : SimpleCondition
    {
        public IsEqual(Field sourceField, Field targetField)
            : base(sourceField, targetField)
        { }

        public override bool IsSimpleConditonHold(IDataSourceStore dsStore)
        {
            return sourceField.IsEqualTo(targetField, dsStore);
        }
    }
}
