using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Presenter for rent vehicle use case.
    /// </summary>
    public sealed class RentVehiclePresenter : IWebApiPresenter, IRentVehicleOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc />
        public void StandardHandle(RentVehicleOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var payload = new RentVehicleResponse(
                response.RentalId,
                response.VehicleId,
                response.PersonId,
                response.StartDateUtc);

            ActionResult = new CreatedResult($"/api/rentals/{payload.RentalId}", payload);
        }

        /// <inheritdoc />
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }
    }
}
