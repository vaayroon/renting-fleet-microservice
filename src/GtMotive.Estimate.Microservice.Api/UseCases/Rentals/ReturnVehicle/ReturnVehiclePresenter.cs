using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Presenter for return vehicle use case.
    /// </summary>
    public sealed class ReturnVehiclePresenter : IWebApiPresenter, IReturnVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc />
        public void StandardHandle(ReturnVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            ActionResult = new OkObjectResult(
                new ReturnVehicleResponse(
                    response.RentalId,
                    response.VehicleId,
                    response.EndDateUtc));
        }

        /// <inheritdoc />
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
