using System;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Request for returning a vehicle.
    /// </summary>
    public sealed class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleRequest"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        public ReturnVehicleRequest(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid RentalId { get; }
    }
}
