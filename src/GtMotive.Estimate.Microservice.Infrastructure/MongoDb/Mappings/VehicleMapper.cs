using System;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Mappings
{
    /// <summary>
    /// Maps vehicle domain entity to Mongo document and vice-versa.
    /// </summary>
    public static class VehicleMapper
    {
        /// <summary>
        /// Converts vehicle domain model to document.
        /// </summary>
        /// <param name="vehicle">Vehicle domain model.</param>
        /// <returns>Mongo document.</returns>
        public static VehicleDocument ToDocument(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            return new VehicleDocument
            {
                Id = vehicle.Id.Value,
                Plate = vehicle.Plate.Value,
                ManufactureDate = vehicle.ManufactureDate,
                Status = vehicle.Status.ToString(),
            };
        }

        /// <summary>
        /// Converts Mongo document to vehicle domain model.
        /// </summary>
        /// <param name="document">Mongo document.</param>
        /// <returns>Vehicle domain model.</returns>
        public static Vehicle ToDomain(VehicleDocument document)
        {
            ArgumentNullException.ThrowIfNull(document);

            var status = Enum.Parse<VehicleStatus>(document.Status);

            return Vehicle.Rehydrate(
                new VehicleId(document.Id),
                new LicensePlate(document.Plate),
                document.ManufactureDate,
                status);
        }
    }
}
