using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(options);

            MongoClient = new MongoClient(options.Value.ConnectionString);
            Database = MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

            // Add call to RegisterBsonClasses() method.
            RegisterBsonClasses();
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }

        private static void RegisterBsonClasses()
        {
            // Intentionally empty: document classes use attributes and do not require explicit class-map registration.
        }
    }
}
