using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model;

namespace Blazor_Eshop_Obligatorisk_Opgave.Repository
{
    public class ProductRepository : IProductService
    {
        public Task<ServiceResponse> AddProduct(Product model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> AddToCart(int productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
