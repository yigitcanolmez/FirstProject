using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


ProductService productService = new ProductService(new InMemoryProductDal());
foreach (var item in productService.GetAll())
{
    Console.WriteLine(item.ProductName + " " + item.UnitPrice +" " + item.UnitsInStock );
}