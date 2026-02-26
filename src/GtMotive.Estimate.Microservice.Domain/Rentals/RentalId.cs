using System;

namespace GtMotive.Estimate.Microservice.Domain.Rentals;

/// <summary>
/// Rental identifier value object.
/// </summary>
public readonly record struct RentalId(Guid Value)
{
    /// <summary>
    /// Creates a new rental identifier.
    /// </summary>
    /// <returns>New identifier.</returns>
    public static RentalId CreateNew() => new(Guid.NewGuid());

    /// <summary>
    /// Returns textual representation.
    /// </summary>
    /// <returns>Identifier string.</returns>
    public override string ToString() => Value.ToString();
}
