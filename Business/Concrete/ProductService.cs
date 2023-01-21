using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.DataResults;
using Core.Utilities.Results.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Net.Http.Headers;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {

            _productDal.Delete(product);
            return new Result(true, Messages.ProductDeleted);

        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new Result(true, Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour>=22 && DateTime.Now.Hour<= 8)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler başarılı bir şekilde getirildi.");
        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product>GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),Messages.ProductGet);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetail());
        }


    }
}
