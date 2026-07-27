using BuildingBlocks.Contracts.Events;

namespace BuildingBlocks.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
        where T : IntegrationEvent;


    Task SubscribeAsync<T, THandler>()
        where T : IntegrationEvent
        where THandler : IEventHandler<T>;
}