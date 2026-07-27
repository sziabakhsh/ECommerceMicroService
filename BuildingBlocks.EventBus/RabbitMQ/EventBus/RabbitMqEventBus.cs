using BuildingBlocks.Contracts.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.RabbitMQ.Consumer;
using BuildingBlocks.EventBus.RabbitMQ.Publisher;

namespace BuildingBlocks.EventBus.RabbitMQ.EventBus;

public sealed class RabbitMqEventBus : IEventBus
{
    private readonly IRabbitMqPublisher _publisher;
    private readonly IRabbitMqConsumer _consumer;


    public RabbitMqEventBus(
        IRabbitMqPublisher publisher,
        IRabbitMqConsumer consumer)
    {
        _publisher = publisher;
        _consumer = consumer;
    }


    public async Task PublishAsync<T>(
        T message,
        CancellationToken cancellationToken = default)
        where T : IntegrationEvent
    {
        await _publisher.PublishAsync(
            message,
            cancellationToken);
    }


    public async Task SubscribeAsync<T, THandler>()
        where T : IntegrationEvent
        where THandler : IEventHandler<T>
    {
        await _consumer.SubscribeAsync<T, THandler>();
    }
}