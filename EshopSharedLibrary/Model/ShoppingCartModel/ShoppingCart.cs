using EshopSharedLibrary.Model.ShoppingCartModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Model.ShoppingCart
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> ItemsInCart { get; set; }
        public ShoppingCart()
        {
            if (ItemsInCart == null)
            {
                ItemsInCart = new List<ShoppingCartItem>();
            }
        }
    }
}
