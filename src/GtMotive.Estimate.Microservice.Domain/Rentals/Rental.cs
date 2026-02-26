using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Rentals;

/// <summary>
/// Represents a vehicle rental lifecycle.
/// </summary>
public sealed class Rental
{
    private Rental(RentalId id, VehicleId vehicleId, PersonId personId, DateTime startDateUtc)
    {
        Id = id;
        VehicleId = vehicleId;
        PersonId = personId;
        StartDateUtc = startDateUtc;
    }

    /// <summary>
    /// Gets rental identifier.
    /// </summary>
    public RentalId Id { get; }

    /// <summary>
    /// Gets rented vehicle identifier.
    /// </summary>
    public VehicleId VehicleId { get; }

    /// <summary>
    /// Gets person identifier.
    /// </summary>
    public PersonId PersonId { get; }

    /// <summary>
    /// Gets rental start date in UTC.
    /// </summary>
    public DateTime StartDateUtc { get; }

    /// <summary>
    /// Gets rental end date in UTC when closed.
    /// </summary>
    public DateTime? EndDateUtc { get; private set; }

    /// <summary>
    /// Gets a value indicating whether rental is active.
    /// </summary>
    public bool IsActive => EndDateUtc is null;

    /// <summary>
    /// Starts a new rental.
    /// </summary>
    /// <param name="id">Rental identifier.</param>
    /// <param name="vehicleId">Vehicle identifier.</param>
    /// <param name="personId">Person identifier.</param>
    /// <param name="utcNow">Current UTC date.</param>
    /// <returns>New active rental.</returns>
    public static Rental StartNew(RentalId id, VehicleId vehicleId, PersonId personId, DateTime utcNow)
    {
        return new Rental(id, vehicleId, personId, utcNow);
    }

    /// <summary>
    /// Closes the rental.
    /// </summary>
    /// <param name="utcNow">Current UTC date.</param>
    public void Return(DateTime utcNow)
    {
        if (!IsActive)
        {
            throw new DomainException("Rental is already closed.");
        }

        EndDateUtc = utcNow;
    }
}
