using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Messaging
{
    /// <summary>
    /// No-op bus used while no real broker integration is configured.
    /// </summary>
    public sealed class NoOpBus : IBus
    {
        /// <inheritdoc />
        public Task Send(object message)
        {
            return Task.CompletedTask;
        }
    }
}
