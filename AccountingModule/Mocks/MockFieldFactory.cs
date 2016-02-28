using AccountingModule.Fields;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Fields.SimpleFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Mocks
{
    class MockFieldFactory : IFieldFactory
    {
        public ComplexField CreateAdditionField()
        {
            return new Addition();
        }

        public ComplexField CreateMultiplicationField()
        {
            return new Multiplication();
        }

        public SimpleField CreateLiteralField(string fieldType, string fieldName, string fieldValue)
        {
            return new LiteralField(fieldType, fieldName, fieldValue);
        }

        public SimpleField CreateTableField(string fieldType, string fieldName)
        {
            return new TableField(fieldType, fieldName);
        }

        public SimpleField CreateSpecialField(string fieldName, string fieldValue)
        {
            return new SpecialField(fieldName, fieldValue);
        }
    }
}
