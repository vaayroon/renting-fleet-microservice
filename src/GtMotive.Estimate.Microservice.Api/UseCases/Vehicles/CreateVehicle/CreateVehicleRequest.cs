using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GtMotive.Estimate.Microservice.Api.UseCases;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Request for creating a vehicle.
    /// </summary>
    public sealed class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        /// <summary>
        /// Gets or sets vehicle plate.
        /// </summary>
        [Required]
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets manufacture date.
        /// </summary>
        [Required]
        [JsonRequired]
        public DateTime ManufactureDate { get; set; }
    }
}
