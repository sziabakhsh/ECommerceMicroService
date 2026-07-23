using OrderService.DTOs.Services;
using System.Net;

namespace OrderService.ServiceClients
{
    public class ProductServiceClient : IProductServiceClient
    {
        private readonly HttpClient _httpClient;
        public ProductServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductDto?> GetProductAsync(Guid id)
        {
            //return await _httpClient.GetFromJsonAsync<ProductDto>(
            //    $"api/product/{id}");

            var response = await _httpClient.GetAsync($"api/product/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ProductDto>();

            //var response = await _httpClient.GetAsync($"api/product/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    var product = await response.Content.ReadFromJsonAsync<ProductDto>();
            //    return product;
            //}
            //return null;
        }
    }
}
