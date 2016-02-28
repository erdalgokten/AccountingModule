using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingModule.Conditions.SimpleConditions;
using AccountingModule.Fields;
using AccountingModule.Fields.SimpleFields;
using AccountingModule.DataSource;
using System.Collections.Generic;

namespace AccountingModule.UnitTest
{
    [TestClass]
    public class IsEqualTest
    {
        [TestMethod]
        public void TestIsEqual_DecimalInt32_Equal()
        {
            Field sourceField = new LiteralField("Decimal", "sourceField", "3000");
            Field targetField = new LiteralField("Int32", "targetField", "3000");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            bool isHold = condition.IsSimpleConditonHold(null);

            bool expected = true;

            Assert.AreEqual<bool>(expected, isHold);
        }

        [TestMethod]
        public void TestIsEqual_DecimalInt32_NotEqual()
        {
            Field sourceField = new LiteralField("Decimal", "sourceField", "2999");
            Field targetField = new LiteralField("Int32", "targetField", "3000");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            bool isHold = condition.IsSimpleConditonHold(null);

            bool expected = false;

            Assert.AreEqual<bool>(expected, isHold);
        }

        [TestMethod]
        public void TestIsEqual_DateTime_Equal()
        {
            Field sourceField = new LiteralField("DateTime", "sourceField", "2016-02-28");
            Field targetField = new LiteralField("DateTime", "targetField", "2016-02-28");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            bool isHold = condition.IsSimpleConditonHold(null);

            bool expected = true;

            Assert.AreEqual<bool>(expected, isHold);
        }

        [TestMethod]
        public void TestIsEqual_DateTime_NotEqual()
        {
            Field sourceField = new LiteralField("DateTime", "sourceField", "2016-02-28");
            Field targetField = new LiteralField("DateTime", "targetField", "2016-02-25");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            bool isHold = condition.IsSimpleConditonHold(null);

            bool expected = false;

            Assert.AreEqual<bool>(expected, isHold);
        }

        [TestMethod]
        public void TestIsEqual_DateTime_Equal_TableField()
        {
            Field sourceField = new LiteralField("DateTime", "sourceField", "2016-02-28");
            Field targetField = new TableField("DateTime", "targetField");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            IDataSourceStore dsStore = new DataSourceStore();
            IDataSource ds = new TableDataSource(new Dictionary<string, object>() { { "targetField", "2016-02-28" } });
            bool isHold = condition.IsSimpleConditonHold(dsStore.AddDataSource(ds));

            bool expected = true;

            Assert.AreEqual<bool>(expected, isHold);
        }

        [TestMethod]
        public void TestIsEqual_DateTime_NotEqual_TableField()
        {
            Field sourceField = new LiteralField("DateTime", "sourceField", "2016-02-28");
            Field targetField = new TableField("DateTime", "targetField");
            SimpleCondition condition = new IsEqual(sourceField, targetField);
            IDataSourceStore dsStore = new DataSourceStore();
            IDataSource ds = new TableDataSource(new Dictionary<string, object>() { { "targetField", "2016-02-27" } });
            bool isHold = condition.IsSimpleConditonHold(dsStore.AddDataSource(ds));

            bool expected = false;

            Assert.AreEqual<bool>(expected, isHold);
        }
    }
}
