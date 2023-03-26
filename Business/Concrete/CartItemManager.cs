using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
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

        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        [TransactionAspect]
        [ValidationAspect(typeof(CartItemValidator))]
        public IResult AddCartItem(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult(Messages.ItemAdded);
        }

        [TransactionAspect]
        public IResult DeleteCartItem(CartItem cartItem)
        {
            _cartItemDal.Delete(cartItem);
            return new SuccessResult(Messages.ItemDeleted);
        }

        [TransactionAspect]
        [ValidationAspect(typeof(CartItemValidator))]
        public IResult UpdateCartItem(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IDataResult<List<CartItem>> GetCartByUserId(int userId)
        {
            var result = _cartItemDal.GetAll(x => x.UserId == userId);
            return new SuccessDataResult<List<CartItem>>(result, Messages.ItemsListed);
        }


    }
}
