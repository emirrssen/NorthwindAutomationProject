using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private ICartItemService _cartItemService;

        public CartItemsController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("Add")]
        public IActionResult AddCartItem(CartItem cartItem)
        {
            var result = _cartItemService.AddCartItem(cartItem);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteCartItem(CartItem cartItem)
        {
            var result = _cartItemService.DeleteCartItem(cartItem);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult UpdateCartItem(CartItem cartItem)
        {
            var result = _cartItemService.UpdateCartItem(cartItem);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCart")]
        public IActionResult GetCartByUserId(int userId)
        {
            var result = _cartItemService.GetCartByUserId(userId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
