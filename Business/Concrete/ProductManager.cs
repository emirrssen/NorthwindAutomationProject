using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult DeleteProduct(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateProduct(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            var result = _productDal.GetAll();
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            var result = _productDal.Get(x => x.ProductId == productId);
            return new SuccessDataResult<Product>(result, Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetails()
        {
            var result = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailsDto>>(result, Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetProductsByCategoryId(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByUnitPriceRange(decimal minValue, decimal maxValue)
        {
            var result = _productDal.GetAll(x => x.UnitPrice >= minValue && x.UnitPrice <= maxValue);
            return new SuccessDataResult<List<Product>>(result, Messages.ProductsListed);
        }
    }
}
