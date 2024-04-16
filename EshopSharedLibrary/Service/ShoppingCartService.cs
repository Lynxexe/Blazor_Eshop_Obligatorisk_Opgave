using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Model.ProductModel;
using EshopSharedLibrary.Model.ShoppingCart;
using EshopSharedLibrary.Model.ShoppingCartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private static ShoppingCart _shoppingCart;
        public event Action OnChange; 
        public ShoppingCartService() 
        {
            if ( _shoppingCart == null)
            {
                _shoppingCart = new ShoppingCart();
            }
        }


        public void AddProduct(Product product, int quantity)
        {
            var existingItem = _shoppingCart.ItemsInCart.FirstOrDefault(item => item.Product?.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.UpdateQuantity(product, quantity);

            }
            else
            {
                _shoppingCart.ItemsInCart.Add(new ShoppingCartItem(product, quantity));
                OnChange?.Invoke();
            }
        }

        public int Count()
        {
            return _shoppingCart.ItemsInCart.Count;
        }

        public void DeleteProduct(ShoppingCartItem item)
        {
            _shoppingCart.ItemsInCart.Remove(item);
            OnChange?.Invoke();
        }

        public ShoppingCart Get()
        {
            return _shoppingCart;
        }

        public bool HasProduct(int Id)
        {
            return _shoppingCart.ItemsInCart.Any(item => item.Product?.Id == Id);
        }
        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (var item in _shoppingCart.ItemsInCart)
            {
                total += item.TotalPrice; 
            }
            return total;
        }
        public void clearCart()
        {
            _shoppingCart = new ShoppingCart();
        }
    }
}
