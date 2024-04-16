using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Interface
{
    public interface IProductService
    {
        ServiceResponse AddProduct(Product model);
        List<Product> GetAllProducts();
        ServiceResponse AddToCart(int productId, int quantity);
        int GetCartCount();
        string GetImageUrl(string filename);
        Product GetProductById(int productId);
    }
}
