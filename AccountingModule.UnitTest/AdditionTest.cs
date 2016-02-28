using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingModule.Fields.ComplexFields;
using AccountingModule.Fields;
using AccountingModule.Fields.SimpleFields;

namespace AccountingModule.UnitTest
{
    [TestClass]
    public class AdditionTest
    {
        [TestMethod]
        public void TestMultiplication_CurrentDate()
        {
            ComplexField addition = new Addition();
            Field operand1 = new SpecialField("operand1", "CurrentDate");
            Field operand2 = new LiteralField("Int32", "operand2", "-4");
            Field operand3 = new LiteralField("Decimal", "operand3", "-1");
            addition.AddField(operand1).AddField(operand2).AddField(operand3);

            DateTime additionResult = (DateTime)addition.GetValue(null);
            DateTime expected = DateTime.Now.Date.AddDays(-5);

            Assert.AreEqual<DateTime>(expected, additionResult);
        }
    }
}
