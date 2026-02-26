using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Lists available vehicles.
    /// </summary>
    public sealed class ListAvailableVehiclesUseCase : IListAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IListAvailableVehiclesOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="outputPort">Output port.</param>
        public ListAvailableVehiclesUseCase(
            IVehicleRepository vehicleRepository,
            IListAvailableVehiclesOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            var availableVehicles = await _vehicleRepository.GetAvailable();

            var output = new List<AvailableVehicleOutputItem>(availableVehicles.Count);

            output.AddRange(
                availableVehicles.Select(
                    vehicle => new AvailableVehicleOutputItem(
                        vehicle.Id.Value,
                        vehicle.Plate.Value,
                        vehicle.ManufactureDate)));

            _outputPort.StandardHandle(new ListAvailableVehiclesOutput(output));
        }
    }
}
