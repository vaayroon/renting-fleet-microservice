using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces;

/// <summary>
/// Repository contract for vehicles.
/// </summary>
public interface IVehicleRepository
{
    /// <summary>
    /// Adds a vehicle.
    /// </summary>
    /// <param name="vehicle">Vehicle to add.</param>
    /// <returns>Task object.</returns>
    Task Add(Vehicle vehicle);

    /// <summary>
    /// Updates a vehicle.
    /// </summary>
    /// <param name="vehicle">Vehicle to update.</param>
    /// <returns>Task object.</returns>
    Task Update(Vehicle vehicle);

    /// <summary>
    /// Gets a vehicle by identifier.
    /// </summary>
    /// <param name="id">Vehicle identifier.</param>
    /// <returns>Vehicle or null reference.</returns>
    Task<Vehicle> GetById(VehicleId id);

    /// <summary>
    /// Gets currently available vehicles.
    /// </summary>
    /// <returns>Available vehicles collection.</returns>
    Task<IReadOnlyCollection<Vehicle>> GetAvailable();

    /// <summary>
    /// Determines whether plate already exists.
    /// </summary>
    /// <param name="plate">Plate to check.</param>
    /// <returns>True if plate exists.</returns>
    Task<bool> ExistsByPlate(LicensePlate plate);
}
