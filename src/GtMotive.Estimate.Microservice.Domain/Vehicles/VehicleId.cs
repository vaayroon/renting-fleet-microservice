using System;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles;

/// <summary>
/// Vehicle identifier value object.
/// </summary>
public readonly record struct VehicleId(Guid Value)
{
    /// <summary>
    /// Creates a new vehicle identifier.
    /// </summary>
    /// <returns>New identifier.</returns>
    public static VehicleId CreateNew() => new(Guid.NewGuid());

    /// <summary>
    /// Returns textual representation.
    /// </summary>
    /// <returns>Identifier string.</returns>
    public override string ToString() => Value.ToString();
}
