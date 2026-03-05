using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using MongoDB.Bson;
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

            // Replace previous non-unique indexes so the database enforces active-rental invariants.
            DropIndexIfExists(collection, "ix_rental_person_active");
            DropIndexIfExists(collection, "ix_rental_vehicle_active");

            var personActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.PersonId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions<RentalDocument>
                {
                    Name = "ux_rental_person_active",
                    Unique = true,
                    PartialFilterExpression = activeFilter,
                });

            var vehicleActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.VehicleId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions<RentalDocument>
                {
                    Name = "ux_rental_vehicle_active",
                    Unique = true,
                    PartialFilterExpression = activeFilter,
                });

            collection.Indexes.CreateOne(personActiveIndex);
            collection.Indexes.CreateOne(vehicleActiveIndex);
        }

        private static void DropIndexIfExists<TDocument>(IMongoCollection<TDocument> collection, string indexName)
        {
            var existingIndexes = collection.Indexes.List().ToList();

            foreach (var existingIndex in existingIndexes)
            {
                if (!existingIndex.TryGetValue("name", out var existingName))
                {
                    continue;
                }

                if (existingName.IsString && existingName.AsString == indexName)
                {
                    collection.Indexes.DropOne(indexName);
                    return;
                }
            }
        }
    }
}
