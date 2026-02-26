using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Returns a rented vehicle.
    /// </summary>
    public sealed class ReturnVehicleUseCase : IReturnVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="outputPort">Output port.</param>
        public ReturnVehicleUseCase(
            IRentalRepository rentalRepository,
            IVehicleRepository vehicleRepository,
            IUnitOfWork unitOfWork,
            IReturnVehicleOutputPort outputPort)
        {
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var rentalId = new RentalId(input.RentalId);
            var rental = await _rentalRepository.GetById(rentalId);

            if (rental == null)
            {
                _outputPort.NotFoundHandle("Rental was not found.");
                return;
            }

            if (!rental.IsActive)
            {
                throw new DomainException("Rental is already closed.");
            }

            var vehicle = await _vehicleRepository.GetById(rental.VehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle("Vehicle linked to rental was not found.");
                return;
            }

            rental.Return(DateTime.UtcNow);
            vehicle.MarkAsAvailable();

            await _rentalRepository.Update(rental);
            await _vehicleRepository.Update(vehicle);
            await _unitOfWork.Save();

            _outputPort.StandardHandle(
                new ReturnVehicleOutput(
                    rental.Id.Value,
                    rental.VehicleId.Value,
                    rental.EndDateUtc.Value));
        }
    }
}
