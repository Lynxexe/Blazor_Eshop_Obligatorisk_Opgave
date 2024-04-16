using EshopSharedLibrary.Model.ProductModel;
using EshopSharedLibrary.Model.ShoppingCart;
using EshopSharedLibrary.Model.ShoppingCartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Interface
{
        public interface IShoppingCartService
        {
            ShoppingCart Get();
            void AddProduct(Product product, int quantity);
            void DeleteProduct(ShoppingCartItem item);
            int Count();
            bool HasProduct(int Id);
            event Action OnChange;
        decimal GetTotal();
        void clearCart();
    }
}
