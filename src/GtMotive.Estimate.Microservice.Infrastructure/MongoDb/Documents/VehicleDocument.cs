using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    /// <summary>
    /// Mongo document for vehicle.
    /// </summary>
    public sealed class VehicleDocument
    {
        /// <summary>
        /// Gets or sets vehicle identifier.
        /// </summary>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets license plate.
        /// </summary>
        [BsonElement("plate")]
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets manufacture date.
        /// </summary>
        [BsonElement("manufactureDate")]
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        [BsonElement("status")]
        public string Status { get; set; }
    }
}
