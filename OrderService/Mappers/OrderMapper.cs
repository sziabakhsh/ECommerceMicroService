using OrderService.Models;
using OrderService.DTOs.Order;

namespace OrderService.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto (this Order order)
        {
            return new OrderDto
            {
                Id= order.Id,
                ProductId= order.ProductId,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate
            };
        }

        public static Order ToOrder(this OrderRequestDto reqDto)
        {
            return new Order
            {
                Id = new Guid(),
                ProductId = reqDto.ProductId,
                Quantity= reqDto.Quantity,
                OrderDate= reqDto.OrderDate
            };
        }
    }
}
