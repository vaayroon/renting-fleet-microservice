using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Mappings;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    /// <summary>
    /// Mongo implementation of vehicle repository.
    /// </summary>
    public sealed class MongoVehicleRepository : IVehicleRepository
    {
        private const string VehiclesCollectionName = "vehicles";

        private readonly IMongoCollection<VehicleDocument> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoVehicleRepository"/> class.
        /// </summary>
        /// <param name="mongoService">Mongo service.</param>
        public MongoVehicleRepository(MongoService mongoService)
        {
            ArgumentNullException.ThrowIfNull(mongoService);

            _collection = mongoService.Database.GetCollection<VehicleDocument>(VehiclesCollectionName);
            EnsureIndexes();
        }

        /// <inheritdoc />
        public async Task Add(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            await _collection.InsertOneAsync(VehicleMapper.ToDocument(vehicle));
        }

        /// <inheritdoc />
        public async Task Update(Vehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var filter = Builders<VehicleDocument>.Filter.Eq(x => x.Id, vehicle.Id.Value);
            await _collection.ReplaceOneAsync(filter, VehicleMapper.ToDocument(vehicle));
        }

        /// <inheritdoc />
        public async Task<Vehicle> GetById(VehicleId id)
        {
            var filter = Builders<VehicleDocument>.Filter.Eq(x => x.Id, id.Value);
            var document = await _collection.Find(filter).FirstOrDefaultAsync();

            return document == null ? null : VehicleMapper.ToDomain(document);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<Vehicle>> GetAvailable()
        {
            var filter = Builders<VehicleDocument>.Filter.Eq(x => x.Status, VehicleStatus.Available.ToString());
            var documents = await _collection.Find(filter).ToListAsync();

            return [.. documents.Select(VehicleMapper.ToDomain)];
        }

        /// <inheritdoc />
        public async Task<bool> ExistsByPlate(LicensePlate plate)
        {
            ArgumentNullException.ThrowIfNull(plate);

            var filter = Builders<VehicleDocument>.Filter.Eq(x => x.Plate, plate.Value);
            return await _collection.Find(filter).AnyAsync();
        }

        private void EnsureIndexes()
        {
            var plateIndex = new CreateIndexModel<VehicleDocument>(
                Builders<VehicleDocument>.IndexKeys.Ascending(x => x.Plate),
                new CreateIndexOptions { Unique = true, Name = "ux_vehicle_plate" });

            _collection.Indexes.CreateOne(plateIndex);
        }
    }
}
