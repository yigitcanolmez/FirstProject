using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


ProductService productService = new ProductService(new EfProductDal());
CategoryService categoryService = new CategoryService(new EfCategoryDal());


foreach (var product in productService.GetByUnitPrice(40, 100))
{
    var categoryName = categoryService.GetById(product.CategoryId);
    Console.WriteLine("{0} Price : {1} Stock Count :{2} Category Name : {3} ", product.ProductName, product.UnitPrice, product.UnitsInStock, categoryName.CategoryName);
}



//foreach (var category in categoryService.GetAll())
//{
//    Console.WriteLine("Category Name: " + category);

//}
