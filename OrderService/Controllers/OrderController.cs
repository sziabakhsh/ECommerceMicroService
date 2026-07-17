using Microsoft.AspNetCore.Mvc;
using OrderService.DTOs.Order;
using OrderService.Interfaces;
using OrderService.Mappers;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            return Ok(orders.Select(o=>o.ToOrderDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.ToOrderDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDto orderRequest)
        {
            var order = orderRequest.ToOrder();
            await _orderRepo.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.ToOrderDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequestDto orderRequest)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order = orderRequest.ToOrder();
            await _orderRepo.UpdateOrderAsync(order);
            return Ok(order.ToOrderDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderRepo.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
