namespace OrderService.DTOs.Services
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        //public string Stock { get; set; } = string.Empty;
    }
}
