using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private ICartItemDal _cartItemDal;
        private IProductService _productService;

        public CartItemManager(ICartItemDal cartItemDal, IProductService productService)
        {
            _cartItemDal = cartItemDal;
            _productService = productService;
        }

        [TransactionAspect]
        [ValidationAspect(typeof(CartItemValidator))]
        [SecuredOperation("user")]
        public IResult AddCartItem(CartItem cartItem)
        {
            var productToCheck = (Product)_productService.GetProductById(cartItem.ProductId);
            var result = BusinessRules.Run(CheckNumberOfUnitsInStock(productToCheck));

            if (result.Success)
            {
                _cartItemDal.Add(cartItem);
                productToCheck.UnitsInStock--;
                _productService.UpdateProduct(productToCheck);
                return new SuccessResult(Messages.ItemAdded);
            }
            return new ErrorResult(result.Message);
        }

        [TransactionAspect]
        [SecuredOperation("user")]
        public IResult DeleteCartItem(CartItem cartItem)
        {
            var productToCheck = (Product)_productService.GetProductById(cartItem.ProductId);

            _cartItemDal.Delete(cartItem);
            productToCheck.UnitsInStock++;
            _productService.UpdateProduct(productToCheck);

            return new SuccessResult(Messages.ItemDeleted);
        }

        [TransactionAspect]
        [ValidationAspect(typeof(CartItemValidator))]
        [SecuredOperation("user")]
        public IResult UpdateCartItem(CartItem cartItem)
        {
            var productToCheck = (Product)_productService.GetProductById(cartItem.ProductId);
            var result = BusinessRules.Run(CheckNumberOfUnitsInStock(productToCheck));

            if (result.Success)
            {
                _cartItemDal.Update(cartItem);
                productToCheck.UnitsInStock--;
                _productService.UpdateProduct(productToCheck);
                return new SuccessResult(Messages.ItemUpdated);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<List<CartItem>> GetCartByUserId(int userId)
        {
            var data = _cartItemDal.GetAll(x => x.UserId == userId);
            return new SuccessDataResult<List<CartItem>>(data, Messages.ItemsListed);
        }

        private IResult CheckNumberOfUnitsInStock(Product product)
        {
            if (product.UnitsInStock == 0)
            {
                return new ErrorResult(Messages.ProductQuantityIsZero);
            }
            return new SuccessResult();
        }
    }
}
