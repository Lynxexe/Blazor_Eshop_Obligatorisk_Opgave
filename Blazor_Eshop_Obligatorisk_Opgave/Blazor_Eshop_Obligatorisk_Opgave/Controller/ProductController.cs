using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model;
using EshopSharedLibrary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_Eshop_Obligatorisk_Opgave.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured)
        {
            var products = await productService.GetAllProducts(); return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is Null");
            var response = await productService.AddProduct(model);
            return Ok(response);
        }
    }
}
