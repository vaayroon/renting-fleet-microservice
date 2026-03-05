using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.DomainEvents
{
    /// <summary>
    /// Dispatches domain events through the configured bus factory.
    /// </summary>
    public sealed class BusDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IBusFactory _busFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusDomainEventDispatcher"/> class.
        /// </summary>
        /// <param name="busFactory">Bus factory.</param>
        public BusDomainEventDispatcher(IBusFactory busFactory)
        {
            _busFactory = busFactory;
        }

        /// <inheritdoc />
        public async Task DispatchAndClear(IEnumerable<AggregateRoot> aggregates)
        {
            ArgumentNullException.ThrowIfNull(aggregates);

            foreach (var aggregate in aggregates)
            {
                ArgumentNullException.ThrowIfNull(aggregate);

                foreach (var domainEvent in aggregate.DomainEvents)
                {
                    var busClient = _busFactory.GetClient(domainEvent.GetType());
                    await busClient.Send(domainEvent);
                }

                aggregate.ClearDomainEvents();
            }
        }
    }
}
