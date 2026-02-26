using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Available vehicle response item.
    /// </summary>
    public sealed class AvailableVehicleResponseItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableVehicleResponseItem"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="manufactureDate">Manufacture date.</param>
        public AvailableVehicleResponseItem(Guid vehicleId, string plate, DateTime manufactureDate)
        {
            VehicleId = vehicleId;
            Plate = plate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets vehicle plate.
        /// </summary>
        [Required]
        public string Plate { get; }

        /// <summary>
        /// Gets manufacture date.
        /// </summary>
        [Required]
        public DateTime ManufactureDate { get; }
    }
}
