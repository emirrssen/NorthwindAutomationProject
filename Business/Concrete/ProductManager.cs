using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Transaction;
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
        private ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [TransactionAspect]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult AddProduct(Product product)
        {
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        [TransactionAspect]
        public IResult DeleteProduct(Product product)
        {
            _productDal.Delete(product);

            return new SuccessResult(Messages.ProductDeleted);
        }

        [TransactionAspect]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult UpdateProduct(Product product)
        {
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductUpdated);
        }

        [TransactionAspect]
        [SecuredOperation("user")]
        public IResult RateProduct(Product product, int rate)
        {
            product.NumberOfRates++;
            product.TotalRates += rate;
            _productDal.Update(product);

            return new SuccessResult(Messages.ProductRated);
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

        public IDataResult<List<ProductDetailsDto>> GetProductsByCategoryId(int categoryId)
        {
            var categoryName = _categoryService.GetCategoryById(categoryId).Data.CategoryName;
            var result = _productDal.GetProductDetails().Where(x => x.CategoryName == categoryName).ToList();

            return new SuccessDataResult<List<ProductDetailsDto>>(result, Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailsDto>> GetProductsByUnitPriceRange(decimal minValue, decimal maxValue)
        {
            var result = _productDal.GetProductDetails().Where(x => x.UnitPrice >= minValue && x.UnitPrice <= maxValue).ToList();

            return new SuccessDataResult<List<ProductDetailsDto>>(result, Messages.ProductsListed);
        }
    }
}
