using Business.Abstract;
using Business.Constant;
using Business.CrossCuttingConcerns;
using Business.ValidationRules.FleuntValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.DataResults;
using Core.Utilities.Results.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System.Net.Http.Headers;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        public ProductService(IProductDal productDal, ILogger logger)
        {
            _productDal = productDal;
            _logger = logger;
        }

        //Validation model ile ilgilidir gelen veri bizim formatımıza uyuyor mu uymuyor mu?
        // Business ise ürün eklenecek, ürün eklemeye hakkımız var mı?
        // CCC => Validation, Log, Cache, Transaction, Authorization

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Business'e eklenilecek???
            if (CheckForSameName(product.ProductName).IsSuccess && CheckProductCountOfCategory(product.CategoryId).IsSuccess)
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }

            return new ErrorResult();
        }

        public IResult Delete(Product product)
        {

            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);

        }
        public IResult Update(Product product)
        {
            var result = BusinessRules.Run(CheckProductCountOfCategory(product.CategoryId));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour >= 21 || DateTime.Now.Hour <= 8)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Ürünler başarılı bir şekilde getirildi.");
        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductGet);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetail());
        }


        private IResult CheckProductCountOfCategory(int categoryId)
        {
            var result = _productDal.GetAll(p => p.ProductId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountForCategory);
            }
            return new SuccessResult();
        }

        private IResult CheckForSameName(string Name)
        {
            var result = _productDal.GetAll(p => p.ProductName == Name).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameExist);
            }
            return new SuccessResult();
        }










    }
}
