using System;
using System.Collections.Generic;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Presenter for list available vehicles use case.
    /// </summary>
    public sealed class ListAvailableVehiclesPresenter : IWebApiPresenter, IListAvailableVehiclesOutputPort
    {
        /// <inheritdoc />
        public IActionResult ActionResult { get; private set; }

        /// <inheritdoc />
        public void StandardHandle(ListAvailableVehiclesOutput response)
        {
            ArgumentNullException.ThrowIfNull(response);

            var payload = new List<AvailableVehicleResponseItem>(response.Vehicles.Count);

            payload.AddRange(
                response.Vehicles.Select(
                    vehicle => new AvailableVehicleResponseItem(
                        vehicle.VehicleId,
                        vehicle.Plate,
                        vehicle.ManufactureDate)));

            ActionResult = new OkObjectResult(payload);
        }
    }
}
