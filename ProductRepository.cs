using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_DEMO.NET_
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (name, price, categoryID) VALUES (@pname, @pprice, @pcategoryID);",
                new { pname = name, pprice = price, pcategoryID = categoryID }); 
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products ORDER BY  name   ");
        }


        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public void UpdateProductName(int productID, string newname)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID;",
                new { newName =newname, productID = productID });
        }

        public void DeleteProduct(int productID)
        {

           
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID ;",
                 new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID ;",
                new { productID = productID });

            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID ;",
                new { productID = productID });

            Console.WriteLine("Product has been succsefully deleted!");




        }




    }


}