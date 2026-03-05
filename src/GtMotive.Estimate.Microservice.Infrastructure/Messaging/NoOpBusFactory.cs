using System;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Messaging
{
    /// <summary>
    /// Returns a no-op bus for any event type.
    /// </summary>
    public sealed class NoOpBusFactory : IBusFactory
    {
        private static readonly IBus SharedClient = new NoOpBus();

        /// <inheritdoc />
        public IBus GetClient(Type eventType)
        {
            return SharedClient;
        }
    }
}
