using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish<T>(T message);

        void Subscribe<T, THandler>()
            where THandler : IEventHandler<T>;
    }
}
