using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Response for return vehicle operation.
    /// </summary>
    public sealed class ReturnVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleResponse"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="endDateUtc">End date UTC.</param>
        public ReturnVehicleResponse(Guid rentalId, Guid vehicleId, DateTime endDateUtc)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            EndDateUtc = endDateUtc;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        [Required]
        public Guid RentalId { get; }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        [Required]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets end date UTC.
        /// </summary>
        [Required]
        public DateTime EndDateUtc { get; }
    }
}
