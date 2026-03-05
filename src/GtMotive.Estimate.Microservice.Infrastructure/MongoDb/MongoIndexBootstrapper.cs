using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    /// <summary>
    /// Centralizes MongoDB index creation for this microservice.
    /// </summary>
    internal static class MongoIndexBootstrapper
    {
        private const string VehiclesCollectionName = "vehicles";
        private const string RentalsCollectionName = "rentals";

        public static void EnsureIndexes(IMongoDatabase database)
        {
            EnsureVehicleIndexes(database);
            EnsureRentalIndexes(database);
        }

        private static void EnsureVehicleIndexes(IMongoDatabase database)
        {
            var collection = database.GetCollection<VehicleDocument>(VehiclesCollectionName);

            var plateIndex = new CreateIndexModel<VehicleDocument>(
                Builders<VehicleDocument>.IndexKeys.Ascending(x => x.Plate),
                new CreateIndexOptions { Unique = true, Name = "ux_vehicle_plate" });

            var statusIndex = new CreateIndexModel<VehicleDocument>(
                Builders<VehicleDocument>.IndexKeys.Ascending(x => x.Status),
                new CreateIndexOptions { Name = "ix_vehicle_status" });

            collection.Indexes.CreateOne(plateIndex);
            collection.Indexes.CreateOne(statusIndex);
        }

        private static void EnsureRentalIndexes(IMongoDatabase database)
        {
            var collection = database.GetCollection<RentalDocument>(RentalsCollectionName);
            var activeFilter = Builders<RentalDocument>.Filter.Eq(x => x.EndDateUtc, null);

            var personActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.PersonId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions<RentalDocument>
                {
                    Name = "ix_rental_person_active",
                    PartialFilterExpression = activeFilter,
                });

            var vehicleActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.VehicleId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions<RentalDocument>
                {
                    Name = "ix_rental_vehicle_active",
                    PartialFilterExpression = activeFilter,
                });

            collection.Indexes.CreateOne(personActiveIndex);
            collection.Indexes.CreateOne(vehicleActiveIndex);
        }
    }
}
