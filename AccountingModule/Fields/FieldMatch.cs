using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields
{
    class FieldMatch
    {
        public Field SourceField { private set; get; }
        public Field TargetField { private set; get; }

        public FieldMatch(Field sourceField, Field targetField)
        {
            this.SourceField = sourceField;
            this.TargetField = targetField;
        }
    }
}
