using ProductService.Models;
using ProductService.DTOs.Product;

namespace ProductService.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto (this Product product)
        {
            return new ProductDto
            {
                Id= product.Id,
                Name= product.Name,
                Description= product.Description,
                Price= product.Price,
                Stock= product.Stock
            };
        }

        public static Product ToProduct(this ProductRequestDto reqDto)
        {
            return new Product
            {
                Id = new Guid(),
                Name = reqDto.Name,
                Description = reqDto.Description,
                Price = reqDto.Price,
                Stock = reqDto.Stock
            };
        }
    }
}
