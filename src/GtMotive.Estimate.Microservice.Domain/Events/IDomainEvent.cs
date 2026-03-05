using System;

namespace GtMotive.Estimate.Microservice.Domain.Events;

/// <summary>
/// Represents a domain event produced by an aggregate.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Gets event occurrence time in UTC.
    /// </summary>
    DateTime OccurredOnUtc { get; }
}
