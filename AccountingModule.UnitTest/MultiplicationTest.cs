using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Fields;
using AccountingModule.Fields.SimpleFields;

namespace AccountingModule.UnitTest
{
    [TestClass]
    public class MultiplicationTest
    {
        [TestMethod]
        public void TestMultiplication_DecimalInt32()
        {
            ComplexField multiplication = new Multiplication();
            Field operand1 = new LiteralField("Decimal", "operand1", "3000");
            Field operand2 = new LiteralField("Int32", "operand2", "-1");
            Field operand3 = new LiteralField("Decimal", "operand3", "3");
            multiplication.AddField(operand1).AddField(operand2).AddField(operand3);

            Decimal multiplicationResult = (Decimal)multiplication.GetValue(null);
            Decimal expected = new Decimal(-9000);

            Assert.AreEqual<Decimal>(expected, multiplicationResult);
        }
    }
}
