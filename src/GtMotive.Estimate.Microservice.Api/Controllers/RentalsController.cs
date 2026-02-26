using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Rentals endpoints.
    /// </summary>
    [ApiController]
    [Route("api/rentals")]
    public sealed class RentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalsController"/> class.
        /// </summary>
        /// <param name="mediator">Mediator instance.</param>
        public RentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Rents a vehicle.
        /// </summary>
        /// <param name="request">Rent vehicle request.</param>
        /// <returns>HTTP result.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody][Required] RentVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Returns a rented vehicle.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <returns>HTTP result.</returns>
        [HttpPost("{rentalId:guid}/return")]
        public async Task<IActionResult> Return([FromRoute] Guid rentalId)
        {
            var presenter = await _mediator.Send(new ReturnVehicleRequest(rentalId));
            return presenter.ActionResult;
        }
    }
}
