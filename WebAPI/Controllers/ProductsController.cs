using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Succes)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Succes)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Succes)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Succes)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Succes)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Succes)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
