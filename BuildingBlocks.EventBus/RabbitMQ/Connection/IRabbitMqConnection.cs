using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.RabbitMQ.Connection
{
    public interface IRabbitMqConnection : IAsyncDisposable
    {
        bool IsConnected { get; }

        Task<IConnection> GetConnectionAsync();
    }
}
