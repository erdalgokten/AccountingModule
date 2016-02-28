using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingModule
{
    public interface IProductFactory
    {
        ProductBase CreateProduct(string productName, string xmlPath);
    }
}
