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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            Console.WriteLine("getting products...");
            var products = await _productService.GetAllProducts(); 
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is Null");
            var response = await _productService.AddProduct(model);
            return Ok(response);
        }

    }
}
