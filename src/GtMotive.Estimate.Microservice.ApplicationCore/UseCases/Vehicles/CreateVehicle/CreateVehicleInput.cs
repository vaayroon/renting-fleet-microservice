using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Input for create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
        /// </summary>
        /// <param name="plate">Vehicle plate.</param>
        /// <param name="manufactureDate">Manufacture date.</param>
        public CreateVehicleInput(string plate, DateTime manufactureDate)
        {
            Plate = plate;
            ManufactureDate = manufactureDate;
        }

        /// <summary>
        /// Gets vehicle plate.
        /// </summary>
        public string Plate { get; }

        /// <summary>
        /// Gets vehicle manufacture date.
        /// </summary>
        public DateTime ManufactureDate { get; }
    }
}
