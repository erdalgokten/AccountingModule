using AccountingModule.Fields.ComplexFields;
using AccountingModule.Fields.SimpleFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule.Fields
{
    interface IFieldFactory
    {
        ComplexField CreateAdditionField();
        ComplexField CreateMultiplicationField();
        SimpleField CreateLiteralField(string fieldType, string fieldName, string fieldValue);
        SimpleField CreateTableField(string fieldType, string fieldName);
        SimpleField CreateSpecialField(string fieldName, string fieldValue);
    }
}
