using System;
using System.Text.RegularExpressions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles;

/// <summary>
/// Value object that represents a vehicle license plate.
/// </summary>
public sealed partial class LicensePlate : IEquatable<LicensePlate>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LicensePlate"/> class.
    /// </summary>
    /// <param name="value">Raw license plate value.</param>
    public LicensePlate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("License plate cannot be empty.");
        }

        var normalizedValue = value.Trim().ToUpperInvariant();

        if (!PlateRegex().IsMatch(normalizedValue))
        {
            throw new DomainException("License plate has an invalid format.");
        }

        Value = normalizedValue;
    }

    /// <summary>
    /// Gets normalized plate value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Returns plate textual value.
    /// </summary>
    /// <returns>Plate value.</returns>
    public override string ToString() => Value;

    /// <summary>
    /// Compares two license plates.
    /// </summary>
    /// <param name="other">Other plate.</param>
    /// <returns>True when both values are equal.</returns>
    public bool Equals(LicensePlate other)
    {
        return other is not null && Value == other.Value;
    }

    /// <summary>
    /// Compares against another object.
    /// </summary>
    /// <param name="obj">Object to compare.</param>
    /// <returns>True when object is a matching plate.</returns>
    public override bool Equals(object obj)
    {
        return obj is LicensePlate other && Equals(other);
    }

    /// <summary>
    /// Gets hash code for this value object.
    /// </summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
    {
        return Value.GetHashCode(StringComparison.Ordinal);
    }

    [GeneratedRegex("^[A-Z0-9-]{4,12}$")]
    private static partial Regex PlateRegex();
}
