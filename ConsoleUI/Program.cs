﻿//////////////using Business.Concrete;
//////////////using DataAccess.Abstract;
//////////////using DataAccess.Concrete.EntityFramework;
//////////////using DataAccess.Concrete.InMemory;
//////////////using Entities.Concrete;
//////////////using Microsoft.EntityFrameworkCore;

////////////////ProductService productService = new ProductService(new EfProductDal(), new DbLoggerCategory());
////////////////CategoryService categoryService = new CategoryService(new EfCategoryDal());

////////////////var productDetail = productService.GetProductDetail();

////////////////foreach (var prodcutDetail in productDetail.Data)
////////////////{
////////////////    Console.WriteLine(prodcutDetail.ProductName + " | " + prodcutDetail.CategoryName);
////////////////}


//////////////////foreach (var product in productService.GetByUnitPrice(40, 100))
//////////////////{
//////////////////    var categoryName = categoryService.GetById(product.CategoryId);
//////////////////    Console.WriteLine("{0} Price : {1} Stock Count :{2} Category Name : {3} ", product.ProductName, product.UnitPrice, product.UnitsInStock, categoryName.CategoryName);
//////////////////}



//////////////////foreach (var category in categoryService.GetAll())
//////////////////{
//////////////////    Console.WriteLine("Category Name: " + category);

//////////////////}
