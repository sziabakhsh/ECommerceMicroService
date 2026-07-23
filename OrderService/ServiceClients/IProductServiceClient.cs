using OrderService.DTOs.Services;

namespace OrderService.ServiceClients
{
    public interface IProductServiceClient
    {
        Task<ProductDto?> GetProductAsync(Guid id);
    }
}
