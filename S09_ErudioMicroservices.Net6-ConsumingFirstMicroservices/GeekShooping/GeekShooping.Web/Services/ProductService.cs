using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShooping.Web.Services
{
    public class ProductService : IProductService
    {
        public readonly HttpClient _client;
        public const string BasePath = "api/v1/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> CreateProduct(ProductModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJsonAsync(BasePath, model);

            if(response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Erro ao realizar create");
            }
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<bool>();
            }
            else
            {
                throw new Exception("Erro ao realizar delete");
            }
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJsonAsync(BasePath, model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Erro ao realizar Update    ");
            }
        }
    }
}
