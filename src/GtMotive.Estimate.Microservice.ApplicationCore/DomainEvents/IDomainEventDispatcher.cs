using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.ApplicationCore.DomainEvents
{
    /// <summary>
    /// Dispatches domain events raised by aggregates.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        /// <summary>
        /// Dispatches events from the provided aggregates and clears them after successful publish.
        /// </summary>
        /// <param name="aggregates">Aggregates containing pending domain events.</param>
        /// <returns>Asynchronous task.</returns>
        Task DispatchAndClear(IEnumerable<AggregateRoot> aggregates);
    }
}
