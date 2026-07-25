
namespace BuildingBlocks.Contracts.Events
{
    public class OrderCreatedEvent: IntegrationEvent
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
