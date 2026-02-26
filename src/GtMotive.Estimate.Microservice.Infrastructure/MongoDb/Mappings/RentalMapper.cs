using System;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Mappings
{
    /// <summary>
    /// Maps rental domain entity to Mongo document and vice-versa.
    /// </summary>
    public static class RentalMapper
    {
        /// <summary>
        /// Converts rental domain model to document.
        /// </summary>
        /// <param name="rental">Rental domain model.</param>
        /// <returns>Mongo document.</returns>
        public static RentalDocument ToDocument(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            return new RentalDocument
            {
                Id = rental.Id.Value,
                VehicleId = rental.VehicleId.Value,
                PersonId = rental.PersonId.Value,
                StartDateUtc = rental.StartDateUtc,
                EndDateUtc = rental.EndDateUtc,
            };
        }

        /// <summary>
        /// Converts Mongo document to rental domain model.
        /// </summary>
        /// <param name="document">Mongo document.</param>
        /// <returns>Rental domain model.</returns>
        public static Rental ToDomain(RentalDocument document)
        {
            ArgumentNullException.ThrowIfNull(document);

            return Rental.Rehydrate(
                new RentalId(document.Id),
                new VehicleId(document.VehicleId),
                new PersonId(document.PersonId),
                document.StartDateUtc,
                document.EndDateUtc);
        }
    }
}
