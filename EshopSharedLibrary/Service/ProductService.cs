using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model;

namespace EshopSharedLibrary.Service
{
    public class ProductService : IProductService
    {
        public List<Product> products = new List<Product>();
        public List<Product> cart = new List<Product>();

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            products.Add(model);
            return new ServiceResponse { Success = true, Message = "Product added successfully" };
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return products;
        }

        public async Task<ServiceResponse> AddToCart(int productId, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Quantity += quantity;
                return new ServiceResponse { Success = true, Message = "Product added to cart" };
            }
            return new ServiceResponse { Success = false, Message = "Product not found" };
        }
    }

}
