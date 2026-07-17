using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Interfaces;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync() =>
            await _context.Products.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(Guid productId) =>
            await _context.Products.FindAsync(productId);

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return false;

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
