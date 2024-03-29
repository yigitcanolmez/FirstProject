﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product
                {
                    ProductId=1,
                    CategoryId=1,
                    ProductName="Kolonya",
                    UnitPrice=15,
                    UnitsInStock=15
                },  new Product
                {
                    ProductId=2,
                    CategoryId=2,
                    ProductName="Para",
                    UnitPrice=500,
                    UnitsInStock=3
                },  new Product
                {
                    ProductId=3,
                    CategoryId=3,
                    ProductName="Peçete",
                    UnitPrice=1500,
                    UnitsInStock=2
                },  new Product
                {
                    ProductId=4,
                    CategoryId=1,
                    ProductName="Ekran",
                    UnitPrice=150,
                    UnitsInStock=65
                },  new Product
                {
                    ProductId=5,
                    CategoryId=1,
                    ProductName="kulaklık",
                    UnitPrice=85,
                    UnitsInStock=1
                }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

      
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();

        }

        public List<ProductDetailDTO> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
