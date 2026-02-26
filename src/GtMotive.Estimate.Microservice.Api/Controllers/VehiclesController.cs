using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Vehicles endpoints.
    /// </summary>
    [ApiController]
    [Route("api/vehicles")]
    public sealed class VehiclesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesController"/> class.
        /// </summary>
        /// <param name="mediator">Mediator instance.</param>
        public VehiclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a vehicle.
        /// </summary>
        /// <param name="request">Create vehicle request.</param>
        /// <returns>HTTP result.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody][Required] CreateVehicleRequest request)
        {
            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        /// <summary>
        /// Lists available vehicles.
        /// </summary>
        /// <returns>HTTP result.</returns>
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var presenter = await _mediator.Send(new ListAvailableVehiclesRequest());
            return presenter.ActionResult;
        }
    }
}
