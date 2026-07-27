using BuildingBlocks.EventBus.RabbitMQ.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace BuildingBlocks.EventBus.RabbitMQ.Connection
{
    public sealed class RabbitMqConnection: IRabbitMqConnection
    {
        private readonly RabbitMqOptions _options;

        private IConnection? _connection;

        public RabbitMqConnection(IOptions<RabbitMqOptions> options)
        {
            _options = options.Value;
        }

        public bool IsConnected =>
            _connection is { IsOpen: true };

        public async Task<IConnection> GetConnectionAsync()
        {
            if (IsConnected)
                return _connection!;

            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password
            };

            _connection = await factory.CreateConnectionAsync();

            return _connection;
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection is not null)
                await _connection.DisposeAsync();
        }
    }
}
