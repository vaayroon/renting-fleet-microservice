using System;
using GtMotive.Estimate.Microservice.Domain.Events;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Events;

/// <summary>
/// Raised when a vehicle is marked as available again.
/// </summary>
/// <param name="VehicleId">Vehicle identifier.</param>
/// <param name="OccurredOnUtc">Event occurrence time in UTC.</param>
public sealed record VehicleReturnedDomainEvent(VehicleId VehicleId, DateTime OccurredOnUtc) : IDomainEvent;
