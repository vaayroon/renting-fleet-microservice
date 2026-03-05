using System;
using GtMotive.Estimate.Microservice.Domain.Events;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Rentals.Events;

/// <summary>
/// Raised when a rental is started.
/// </summary>
/// <param name="RentalId">Rental identifier.</param>
/// <param name="VehicleId">Vehicle identifier.</param>
/// <param name="PersonId">Person identifier.</param>
/// <param name="OccurredOnUtc">Event occurrence time in UTC.</param>
public sealed record RentalStartedDomainEvent(
    RentalId RentalId,
    VehicleId VehicleId,
    PersonId PersonId,
    DateTime OccurredOnUtc) : IDomainEvent;
