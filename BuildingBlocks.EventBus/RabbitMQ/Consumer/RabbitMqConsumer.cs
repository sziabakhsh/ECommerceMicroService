using System.Text;
using System.Text.Json;
using BuildingBlocks.Contracts.Events;
using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.RabbitMQ.Connection;
using BuildingBlocks.EventBus.RabbitMQ.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BuildingBlocks.EventBus.RabbitMQ.Consumer;


public sealed class RabbitMqConsumer : IRabbitMqConsumer
{
    private readonly IRabbitMqConnection _connection;
    private readonly RabbitMqOptions _options;


    public RabbitMqConsumer(
        IRabbitMqConnection connection,
        IOptions<RabbitMqOptions> options)
    {
        _connection = connection;
        _options = options.Value;
    }



    public async Task SubscribeAsync<T, THandler>()
        where T : IntegrationEvent
        where THandler : IEventHandler<T>
    {
        var channel =
            await (
                await _connection.GetConnectionAsync()
            ).CreateChannelAsync();


        await channel.ExchangeDeclareAsync(
            _options.ExchangeName,
            ExchangeType.Topic,
            durable: true);



        var queueName = typeof(THandler).Name;


        await channel.QueueDeclareAsync(
            queueName,
            durable: true,
            exclusive: false,
            autoDelete: false);



        await channel.QueueBindAsync(
            queueName,
            _options.ExchangeName,
            typeof(T).Name);



        var consumer = new AsyncEventingBasicConsumer(channel);


        consumer.ReceivedAsync += async (_, args) =>
        {
            var json =
                Encoding.UTF8.GetString(args.Body.ToArray());


            var message =
                JsonSerializer.Deserialize<T>(json);


            if (message != null)
            {
                var handler =
                    Activator.CreateInstance<THandler>();

                await handler.Handle(message);
            }


            await channel.BasicAckAsync(
                args.DeliveryTag,
                false);
        };


        await channel.BasicConsumeAsync(
            queueName,
            autoAck: false,
            consumer);
    }
}