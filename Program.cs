using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper_DEMO.NET_;

IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var repo = new DepartmentRepository(conn);

var productrepo = new ProductRepository(conn);

repo.InsertDepartment("My new Department!");

var departments = repo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.Name);
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine();
    Console.WriteLine();
}

var products = productrepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.ProductID);
    Console.WriteLine();
    Console.WriteLine();
}
bool isnumber;
bool isnubmer2;
do
{
    Console.WriteLine("Enter a new product name to add the the list of products");
    var newproductname = Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("Enter the price of the new product");
    var userinput = Console.ReadLine();
    double newproductprice;
    isnumber = double.TryParse(userinput, out newproductprice);
    Console.WriteLine();
    Console.WriteLine("Enter the CategoryID for the new product");
    var userinput2 = Console.ReadLine();
    int productcategoryid;
    isnubmer2 = int.TryParse(userinput2, out productcategoryid);

    productrepo.CreateProduct(newproductname, newproductprice, productcategoryid);

} while (isnumber == false || isnubmer2 == false);

var newproducts =productrepo.GetAllProducts();

foreach (var product in newproducts)
{
    Console.WriteLine("************************************");
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.ProductID);
    Console.WriteLine();
    Console.WriteLine();

}

productrepo.UpdateProductName(940, "Halo Infinite 2");

var updatedproducts = productrepo.GetAllProducts();

foreach(var product in updatedproducts)
{
    Console.WriteLine("************************************");
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.ProductID);
    Console.WriteLine();
    Console.WriteLine();
}

productrepo.DeleteProduct(940);

var deletedproducts = productrepo.GetAllProducts();

foreach( var product in deletedproducts)
{
    Console.WriteLine("************************************");
    Console.WriteLine(product.Name);
    Console.WriteLine($"${product.Price}");
    Console.WriteLine(product.ProductID);
    Console.WriteLine();
    Console.WriteLine();
}

    


