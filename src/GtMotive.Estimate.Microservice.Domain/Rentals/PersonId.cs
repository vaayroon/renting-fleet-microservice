using System;

namespace GtMotive.Estimate.Microservice.Domain.Rentals;

/// <summary>
/// Person identifier value object.
/// </summary>
public readonly record struct PersonId(Guid Value)
{
    /// <summary>
    /// Creates a new person identifier.
    /// </summary>
    /// <returns>New identifier.</returns>
    public static PersonId CreateNew() => new(Guid.NewGuid());

    /// <summary>
    /// Returns textual representation.
    /// </summary>
    /// <returns>Identifier string.</returns>
    public override string ToString() => Value.ToString();
}
