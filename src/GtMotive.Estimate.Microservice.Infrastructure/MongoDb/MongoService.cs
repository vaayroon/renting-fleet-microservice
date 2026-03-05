using System;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService
    {
        public MongoService(IOptions<MongoDbSettings> options, IHostEnvironment hostEnvironment)
        {
            ArgumentNullException.ThrowIfNull(options);
            ArgumentNullException.ThrowIfNull(hostEnvironment);

            MongoClient = new MongoClient(options.Value.ConnectionString);
            Database = MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

            if (ShouldAutoEnsureIndexes(options.Value, hostEnvironment))
            {
                // Keep automatic index bootstrapping for local development only.
                MongoIndexBootstrapper.EnsureIndexes(Database);
            }

            // Add call to RegisterBsonClasses() method.
            RegisterBsonClasses();
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }

        public void RunIndexMigrations()
        {
            MongoIndexBootstrapper.EnsureIndexes(Database);
        }

        private static void RegisterBsonClasses()
        {
            // Intentionally empty: document classes use attributes and do not require explicit class-map registration.
        }

        private static bool ShouldAutoEnsureIndexes(MongoDbSettings settings, IHostEnvironment hostEnvironment)
        {
            return settings.EnsureIndexesOnStartup && hostEnvironment.IsDevelopment();
        }
    }
}
