using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EshopSharedLibrary.Model.ProductModel;

namespace EshopSharedLibrary.Model.ShoppingCartModel
{
    public class ShoppingCartItem
    {
        public Product? Product { get; }
        public decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal TotalPrice
        {
            get
            {
                return Price * Quantity;
            }
        }
        public ShoppingCartItem(Product product, int quantity)
        {
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }
        public void UpdateQuantity(Product product, int quantity)
        {
            Price = product.Price;
            Quantity += quantity;
        }
    }
}
