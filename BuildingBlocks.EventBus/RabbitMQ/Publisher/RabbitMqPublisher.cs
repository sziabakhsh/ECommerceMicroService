using BuildingBlocks.Contracts.Events;

namespace BuildingBlocks.EventBus.RabbitMQ.Publisher
{
    public class RabbitMqPublisher : IRabbitMqPublisher
    {
        public Task PublishAsync<T>(
            T @event,
            CancellationToken cancellationToken = default)
        where T : IntegrationEvent
        {
            throw new NotImplementedException();
        }
    }
}
