using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Model.ProductModel;


namespace EshopSharedLibrary.Service
{
    public class ProductService : IProductService //Skal håndtere på ServerSiden, ClientService er beregnet til at blive brugt på Client-siden og kommunikere via HTTP Requests.
    {
        public List<Product> products;
        public List<Product> cart = new List<Product>(); //Bruges ikke.

        public ProductService()
        {
            products = new List<Product>()
            {
                new Product(1, "BUBBLES-GUMBALL-APRON", "A Gumball for Your Thoughts Apron", 24, "bubbles-gumball-apron-black.jpg"),
                new Product(2, "REX-MICROCONTROLLERS-APRON", "Great Microcontrollers Think Alike Apron", 24, "rex-microcontrollers-apron-black.jpg"),
                new Product(3, "DOLORES-COMPUTE-BASEBALLHAT", "I Compute, Therefore I Am Baseball Hat", 29, "dolores-compute-baseballhat-black.jpg"),
                new Product(4, "BUBBLES-GUMBALL-BASEBALLHAT", "A Gumball for Your Thoughts Baseball Hat", 29, "bubbles-gumball-baseballhat-black.jpg"),
                new Product(5, "REX-MICROCONTROLLERS-BASEBALLHAT", "Great Microcontrollers Think Alike Baseball Hat", 29, "rex-microcontrollers-baseballhat-black.jpg"),
                new Product(6, "DOLORES-COMPUTE-MUG", "I Compute, Therefore I Am Mug", 16, "dolores-compute-mug-black.jpg"),
                new Product(7, "DOLORES-COMPUTE-TSHIRT", "I Compute, Therefore I Am T-shirt", 26, "dolores-compute-tshirt-black.jpg"),
                new Product(8, "REX-MICROCONTROLLERS-TSHIRT", "Great Microcontrollers Think Alike T-shirt", 26, "rex-microcontrollers-tshirt-black.jpg")
            };
        }

        public ServiceResponse AddProduct(Product model)
        {
            products.Add(model);
            return new ServiceResponse { Success = true, Message = "Product added successfully" };
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public ServiceResponse AddToCart(int productId, int quantity)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                return new ServiceResponse { Success = true, Message = "Product added to cart" };
            }
            return new ServiceResponse { Success = false, Message = "Product not found" };
        }
        public int GetCartCount()
        {
            return cart.Count;
        }
        public string GetImageUrl(string filename)
        {
            return $"/images/{filename}";
        }
        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
