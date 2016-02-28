using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountingModule.Mocks;
using System.IO;
using AccountingModule.DataSource;
using System.Collections.Generic;
using AccountingModule.Misc;

namespace AccountingModule.UnitTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        [ExpectedException(typeof(AccountingModuleException))]
        public void TestProduct1()
        {
            IProductFactory pf = new MockProductFactory();
            string xmlPath = Path.Combine(Environment.CurrentDirectory, "ProductSample.xml");
            ProductBase product = pf.CreateProduct("TestProduct", xmlPath);

            // as if we are taking order transactions from database
            Dictionary<string, object> row = new Dictionary<string, object>();
            row.Add("Amount", 3000);
            //row.Add("Amount", (Decimal)3000);
            //row.Add("Amount", DBNull.Value);
            //row.Add("Amount", null);
            row.Add("DealPrice", (Decimal)1.25);
            row.Add("DealerID", "Somebody");

            IDataSourceStore dsStore = new DataSourceStore();
            IDataSource ds = new TableDataSource(row);
            dsStore.AddDataSource(ds);

            foreach (var evDef in product.GetHoldEvents(dsStore))
            {
                foreach (var result in product.TakeReactionsFor(evDef, dsStore))
                {
                    Decimal amount = (Decimal)result.Item2["Amount"];
                    Assert.AreEqual<Decimal>(-3000, amount);
                    // insert dictionary columns into database accounting table
                }
            }
        }
    }
}
