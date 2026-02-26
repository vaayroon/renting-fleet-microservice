using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.Vehicles;

/// <summary>
/// Represents a vehicle in the fleet.
/// </summary>
public sealed class Vehicle
{
    private Vehicle(
        VehicleId id,
        LicensePlate plate,
        DateTime manufactureDate,
        VehicleStatus status)
    {
        Id = id;
        Plate = plate;
        ManufactureDate = manufactureDate;
        Status = status;
    }

    /// <summary>
    /// Gets vehicle identifier.
    /// </summary>
    public VehicleId Id { get; }

    /// <summary>
    /// Gets vehicle plate.
    /// </summary>
    public LicensePlate Plate { get; }

    /// <summary>
    /// Gets vehicle manufacture date.
    /// </summary>
    public DateTime ManufactureDate { get; }

    /// <summary>
    /// Gets vehicle status.
    /// </summary>
    public VehicleStatus Status { get; private set; }

    /// <summary>
    /// Gets a value indicating whether vehicle is available.
    /// </summary>
    public bool IsAvailable => Status == VehicleStatus.Available;

    /// <summary>
    /// Creates a vehicle ensuring domain constraints.
    /// </summary>
    /// <param name="id">Vehicle identifier.</param>
    /// <param name="plate">Vehicle plate.</param>
    /// <param name="manufactureDate">Vehicle manufacture date.</param>
    /// <param name="utcNow">Current UTC date.</param>
    /// <returns>New vehicle instance.</returns>
    public static Vehicle Create(
        VehicleId id,
        LicensePlate plate,
        DateTime manufactureDate,
        DateTime utcNow)
    {
        return manufactureDate.Date < utcNow.Date.AddYears(-5)
            ? throw new VehicleTooOldException(manufactureDate)
            : new Vehicle(id, plate, manufactureDate.Date, VehicleStatus.Available);
    }

    /// <summary>
    /// Rehydrates a vehicle from persistence.
    /// </summary>
    /// <param name="id">Vehicle identifier.</param>
    /// <param name="plate">Vehicle plate.</param>
    /// <param name="manufactureDate">Vehicle manufacture date.</param>
    /// <param name="status">Vehicle status.</param>
    /// <returns>Rehydrated vehicle.</returns>
    public static Vehicle Rehydrate(
        VehicleId id,
        LicensePlate plate,
        DateTime manufactureDate,
        VehicleStatus status)
    {
        return new Vehicle(id, plate, manufactureDate, status);
    }

    /// <summary>
    /// Marks vehicle as rented.
    /// </summary>
    public void MarkAsRented()
    {
        if (!IsAvailable)
        {
            throw new DomainException("Vehicle is not available for rent.");
        }

        Status = VehicleStatus.Rented;
    }

    /// <summary>
    /// Marks vehicle as available.
    /// </summary>
    public void MarkAsAvailable()
    {
        Status = VehicleStatus.Available;
    }
}
