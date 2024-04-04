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
        public string Sku { get; }

        public string Name { get; }

        public decimal Price { get; }

        public string Image { get; }

        public string FullUrl
        {
            get
            {
                return string.Format("/product/{0}", Id);
            }
        }
        public Product(int id, string sku, string name, decimal price, string image)
        {
            Id = id;
            Sku = sku;
            Name = name;
            Price = price;
            Image = image;
        }
    }
}
