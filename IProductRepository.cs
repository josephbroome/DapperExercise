using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DEMO.NET_
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);



    }
}