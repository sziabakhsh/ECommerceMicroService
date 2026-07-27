using BuildingBlocks.EventBus.Abstractions;
using BuildingBlocks.EventBus.RabbitMQ.Configuration;
using BuildingBlocks.EventBus.RabbitMQ.Connection;
using BuildingBlocks.EventBus.RabbitMQ.Consumer;
using BuildingBlocks.EventBus.RabbitMQ.EventBus;
using BuildingBlocks.EventBus.RabbitMQ.Publisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BuildingBlocks.EventBus.DependencyInjection
{
    public static class EventBusServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(
                configuration.GetSection(RabbitMqOptions.SectionName));

            services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();

            services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();

            services.AddSingleton<IRabbitMqConsumer, RabbitMqConsumer>();

            services.AddSingleton<IEventBus, RabbitMqEventBus>();

            return services;
        }
    }
}
