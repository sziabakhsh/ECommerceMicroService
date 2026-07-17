using System.ComponentModel.DataAnnotations;

namespace OrderService.DTOs.Order
{
    public class OrderRequestDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
