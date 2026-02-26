using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Creates a vehicle in the fleet.
    /// </summary>
    public sealed class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="outputPort">Output port.</param>
        public CreateVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            ICreateVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var plate = new LicensePlate(input.Plate);

            if (await _vehicleRepository.ExistsByPlate(plate))
            {
                throw new DomainException("Vehicle with same plate already exists.");
            }

            var vehicle = Vehicle.Create(
                VehicleId.CreateNew(),
                plate,
                input.ManufactureDate,
                DateTime.UtcNow);

            await _vehicleRepository.Add(vehicle);
            await _unitOfWork.Save();

            _outputPort.StandardHandle(
                new CreateVehicleOutput(
                    vehicle.Id.Value,
                    vehicle.Plate.Value,
                    vehicle.ManufactureDate));
        }
    }
}
