using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces;

/// <summary>
/// Repository contract for rentals.
/// </summary>
public interface IRentalRepository
{
    /// <summary>
    /// Adds a rental.
    /// </summary>
    /// <param name="rental">Rental to add.</param>
    /// <returns>Task object.</returns>
    Task Add(Rental rental);

    /// <summary>
    /// Updates a rental.
    /// </summary>
    /// <param name="rental">Rental to update.</param>
    /// <returns>Task object.</returns>
    Task Update(Rental rental);

    /// <summary>
    /// Gets a rental by identifier.
    /// </summary>
    /// <param name="id">Rental identifier.</param>
    /// <returns>Rental or null reference.</returns>
    Task<Rental> GetById(RentalId id);

    /// <summary>
    /// Gets active rental by person.
    /// </summary>
    /// <param name="personId">Person identifier.</param>
    /// <returns>Active rental or null reference.</returns>
    Task<Rental> GetActiveByPersonId(PersonId personId);

    /// <summary>
    /// Gets active rental by vehicle.
    /// </summary>
    /// <param name="vehicleId">Vehicle identifier.</param>
    /// <returns>Active rental or null reference.</returns>
    Task<Rental> GetActiveByVehicleId(VehicleId vehicleId);
}
