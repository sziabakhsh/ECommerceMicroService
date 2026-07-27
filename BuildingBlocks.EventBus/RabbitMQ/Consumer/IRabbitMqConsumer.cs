using BuildingBlocks.Contracts.Events;
using BuildingBlocks.EventBus.Abstractions;

namespace BuildingBlocks.EventBus.RabbitMQ.Consumer;

public interface IRabbitMqConsumer
{
    Task SubscribeAsync<T, THandler>()
        where T : IntegrationEvent
        where THandler : IEventHandler<T>;
}