using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Request for renting a vehicle.
    /// </summary>
    public sealed class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets vehicle identifier.
        /// </summary>
        [Required]
        [JsonRequired]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets person identifier.
        /// </summary>
        [Required]
        [JsonRequired]
        public Guid PersonId { get; set; }
    }
}
