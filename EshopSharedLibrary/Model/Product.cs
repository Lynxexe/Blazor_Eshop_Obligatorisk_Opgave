using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSharedLibrary.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public string FullUrl
        {
            get
            {
                return string.Format("/product/{0}", Id);
            }
        }
    }
}
