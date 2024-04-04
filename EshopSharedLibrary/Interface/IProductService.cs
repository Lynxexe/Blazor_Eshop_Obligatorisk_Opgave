using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Interface
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts();
        Task<ServiceResponse> AddToCart(int productId, int quantity);
    }
}
