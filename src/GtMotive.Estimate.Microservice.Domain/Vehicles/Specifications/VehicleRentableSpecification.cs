using System;
using GtMotive.Estimate.Microservice.Domain.Specifications;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles.Specifications;

/// <summary>
/// Validates whether a vehicle can be rented right now.
/// </summary>
public sealed class VehicleRentableSpecification : ISpecification<Vehicle>
{
    /// <inheritdoc />
    public bool IsSatisfiedBy(Vehicle candidate)
    {
        ArgumentNullException.ThrowIfNull(candidate);

        return candidate.IsAvailable;
    }
}
