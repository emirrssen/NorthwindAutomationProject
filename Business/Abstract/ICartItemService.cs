using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartItemService 
    {
        IDataResult<List<CartItem>> GetCartByUserId(int userId);
        IResult AddCartItem(CartItem cartItem);
        IResult DeleteCartItem(CartItem cartItem);
        IResult UpdateCartItem(CartItem cartItem);
    }
}
