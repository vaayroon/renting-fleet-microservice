using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Available vehicle item.
    /// </summary>
    public sealed class AvailableVehicleOutputItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableVehicleOutputItem"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="plate">Plate value.</param>
        /// <param name="manufactureDate">Manufacture date.</param>
        public AvailableVehicleOutputItem(Guid vehicleId, string plate, DateTime manufactureDate)
        {
            VehicleId = vehicleId;
            Plate = plate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets plate value.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; }
    }
}
