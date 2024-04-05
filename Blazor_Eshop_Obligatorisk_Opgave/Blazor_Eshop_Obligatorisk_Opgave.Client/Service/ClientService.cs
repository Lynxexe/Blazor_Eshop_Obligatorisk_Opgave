using System.Text.Json.Serialization;
using System.Text.Json;
using EshopSharedLibrary.Json;
using EshopSharedLibrary.Interface;
using EshopSharedLibrary.Model.ProductModel;

namespace Blazor_Eshop_Obligatorisk_Opgave.Client.Service
{
    public class ClientService (HttpClient httpClient) : IProductService //Skal håndtere Client Siden, ProductService er beregnet til at blive brugt på server-siden og bruger in-memory.
    {
        private const string BaseUrl = "api/product";

        private static string SerializeObj(object modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serialiazedObj) => new(serialiazedObj, System.Text.Encoding.UTF8, "application/json");
        private static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            var response = await httpClient.PostAsync(BaseUrl, GenerateStringContent(SerializeObj(model)));

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse(false, "Error occured, failed in AddProduct. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response = await httpClient.GetAsync($"{BaseUrl}");
            if (!response.IsSuccessStatusCode) return null!;

            var result = await response.Content.ReadAsStringAsync();
            return [.. DeserializeJsonStringList<Product>(result)];
        }

        public async Task<ServiceResponse> AddToCart(int productId, int quantity)
        {
            var response = await httpClient.PutAsync($"{BaseUrl}/{productId}/{quantity}", null);

            //Read Response
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse(false, "Error occured while adding the product to the cart. Try again later...");

            var apiResponse = await response.Content.ReadAsStringAsync();
            return DeserializeJsonString<ServiceResponse>(apiResponse);
        }

        Task<int> IProductService.GetCartCount()
        {
            return null;
        }
        public string GetImageUrl(string filename)
        {
            // Assuming your images are served from the 'images' folder under 'wwwroot'
            return $"/images/{filename}";
        }
    }
}
