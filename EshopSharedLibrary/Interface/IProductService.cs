using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Interface
{
    public interface IProductService //Er ikke helt 100% på den her service men den er sat så serveren kan bruge den.
    {
        ServiceResponse AddProduct(Product model);
        List<Product> GetAllProducts();
        ServiceResponse AddToCart(int productId, int quantity);
        int GetCartCount();
        string GetImageUrl(string filename);
    }
}
