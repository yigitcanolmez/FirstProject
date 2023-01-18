using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll(); 
        }

        public List<Product> GetAllCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return _productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice);
        }
    }
}
