using BuildingBlocks.Contracts.Events;

namespace BuildingBlocks.EventBus.RabbitMQ.Publisher
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default)
        where T : IntegrationEvent;
    }
}
