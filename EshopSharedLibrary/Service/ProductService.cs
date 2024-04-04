using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model;

namespace EshopSharedLibrary.Service
{
    public class ProductService : IProductService //Skal håndtere på ServerSiden, ClientService er beregnet til at blive brugt på Client-siden og kommunikere via HTTP Requests.
    {
        public List<Product> products;
        public List<Product> cart = new List<Product>();

        private readonly List<Product> _products;

        public ProductService()
        {
            products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
            // Tilføj flere produkter efter behov
        };
        }

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
        public async Task<int> GetCartCount()
        {
            return cart.Count;
        }
    }
}
