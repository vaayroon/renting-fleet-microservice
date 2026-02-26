using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Mappings;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    /// <summary>
    /// Mongo implementation of rental repository.
    /// </summary>
    public sealed class MongoRentalRepository : IRentalRepository
    {
        private const string RentalsCollectionName = "rentals";

        private readonly IMongoCollection<RentalDocument> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRentalRepository"/> class.
        /// </summary>
        /// <param name="mongoService">Mongo service.</param>
        public MongoRentalRepository(MongoService mongoService)
        {
            ArgumentNullException.ThrowIfNull(mongoService);

            _collection = mongoService.Database.GetCollection<RentalDocument>(RentalsCollectionName);
            EnsureIndexes();
        }

        /// <inheritdoc />
        public async Task Add(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            await _collection.InsertOneAsync(RentalMapper.ToDocument(rental));
        }

        /// <inheritdoc />
        public async Task Update(Rental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            var filter = Builders<RentalDocument>.Filter.Eq(x => x.Id, rental.Id.Value);
            await _collection.ReplaceOneAsync(filter, RentalMapper.ToDocument(rental));
        }

        /// <inheritdoc />
        public async Task<Rental> GetById(RentalId id)
        {
            var filter = Builders<RentalDocument>.Filter.Eq(x => x.Id, id.Value);
            var document = await _collection.Find(filter).FirstOrDefaultAsync();

            return document == null ? null : RentalMapper.ToDomain(document);
        }

        /// <inheritdoc />
        public async Task<Rental> GetActiveByPersonId(PersonId personId)
        {
            var filter = Builders<RentalDocument>.Filter.And(
                Builders<RentalDocument>.Filter.Eq(x => x.PersonId, personId.Value),
                Builders<RentalDocument>.Filter.Eq(x => x.EndDateUtc, null));

            var document = await _collection.Find(filter).FirstOrDefaultAsync();

            return document == null ? null : RentalMapper.ToDomain(document);
        }

        /// <inheritdoc />
        public async Task<Rental> GetActiveByVehicleId(VehicleId vehicleId)
        {
            var filter = Builders<RentalDocument>.Filter.And(
                Builders<RentalDocument>.Filter.Eq(x => x.VehicleId, vehicleId.Value),
                Builders<RentalDocument>.Filter.Eq(x => x.EndDateUtc, null));

            var document = await _collection.Find(filter).FirstOrDefaultAsync();

            return document == null ? null : RentalMapper.ToDomain(document);
        }

        private void EnsureIndexes()
        {
            var personActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.PersonId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions { Name = "ix_rental_person_active" });

            var vehicleActiveIndex = new CreateIndexModel<RentalDocument>(
                Builders<RentalDocument>.IndexKeys.Ascending(x => x.VehicleId).Ascending(x => x.EndDateUtc),
                new CreateIndexOptions { Name = "ix_rental_vehicle_active" });

            _collection.Indexes.CreateOne(personActiveIndex);
            _collection.Indexes.CreateOne(vehicleActiveIndex);
        }
    }
}
