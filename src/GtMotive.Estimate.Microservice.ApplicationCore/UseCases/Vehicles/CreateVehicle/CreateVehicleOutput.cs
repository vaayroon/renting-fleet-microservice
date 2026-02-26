using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Output of create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="manufactureDate">Manufacture date.</param>
        public CreateVehicleOutput(Guid vehicleId, string plate, DateTime manufactureDate)
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
        /// Gets vehicle plate.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; }
    }
}
