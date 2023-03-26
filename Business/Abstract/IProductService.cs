using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult AddProduct(Product product);
        IResult UpdateProduct(Product product);
        IResult DeleteProduct(Product product);
        IResult RateProduct(Product product, int rate);
        IDataResult<Product> GetProductById(int productId);
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<List<ProductDetailsDto>> GetProductDetails();
        IDataResult<List<ProductDetailsDto>> GetProductsByCategoryId(int categoryId);
        IDataResult<List<ProductDetailsDto>> GetProductsByUnitPriceRange(decimal minValue, decimal maxValue);
    }
}
