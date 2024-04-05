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
        public IList<ShoppingCartItem>? Items { get; init; }
        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }
    }
}
