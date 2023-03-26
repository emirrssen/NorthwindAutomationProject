using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Add")]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.AddProduct(product);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = _productService.DeleteProduct(product);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.UpdateProduct(product);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetDetails")]
        public IActionResult GetProductDetails()
        {
            var result = _productService.GetProductDetails();
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var result = _productService.GetProductsByCategoryId(categoryId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
