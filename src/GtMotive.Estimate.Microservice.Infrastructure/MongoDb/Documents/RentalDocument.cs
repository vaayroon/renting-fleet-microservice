using System;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Documents
{
    /// <summary>
    /// Mongo document for rental.
    /// </summary>
    public sealed class RentalDocument
    {
        /// <summary>
        /// Gets or sets rental identifier.
        /// </summary>
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets vehicle identifier.
        /// </summary>
        [BsonElement("vehicleId")]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets person identifier.
        /// </summary>
        [BsonElement("personId")]
        public Guid PersonId { get; set; }

        /// <summary>
        /// Gets or sets start date UTC.
        /// </summary>
        [BsonElement("startDateUtc")]
        public DateTime StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets end date UTC.
        /// </summary>
        [BsonElement("endDateUtc")]
        [BsonIgnoreIfNull]
        public DateTime? EndDateUtc { get; set; }
    }
}
