using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Response for rent vehicle operation.
    /// </summary>
    public sealed class RentVehicleResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleResponse"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="startDateUtc">Start date UTC.</param>
        public RentVehicleResponse(Guid rentalId, Guid vehicleId, Guid personId, DateTime startDateUtc)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            PersonId = personId;
            StartDateUtc = startDateUtc;
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
        /// Gets person identifier.
        /// </summary>
        [Required]
        public Guid PersonId { get; }

        /// <summary>
        /// Gets start date UTC.
        /// </summary>
        [Required]
        public DateTime StartDateUtc { get; }
    }
}
