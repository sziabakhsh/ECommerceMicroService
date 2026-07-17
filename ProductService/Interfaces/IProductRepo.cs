using ProductService.Models;

namespace ProductService.Interfaces
{
    public interface IProductRepo
    {

            Task<Product> GetProductByIdAsync(Guid productId);
            Task<List<Product?>> GetAllProductsAsync();
            Task<Product> CreateProductAsync(Product product);
            Task<Product> UpdateProductAsync(Product product);
            Task<bool> DeleteProductAsync(Guid productId);
 
    }
}
