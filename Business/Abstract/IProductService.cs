using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice);
        IDataResult<List<ProductDetailDTO>> GetProductDetail();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

    }
}
