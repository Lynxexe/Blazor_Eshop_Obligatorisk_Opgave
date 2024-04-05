using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Model.ShoppingCartModel
{
public class ShoppingCartCount
    {
        public int Count { get; set; }

        public event Action? CountChange;

        public void OnCountChange()
        {
            CountChange?.Invoke();
        }

    }
}
