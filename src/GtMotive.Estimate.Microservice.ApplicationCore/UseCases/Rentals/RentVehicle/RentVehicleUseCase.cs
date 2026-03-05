using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.DomainEvents;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Common;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Specifications;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Rents a vehicle to a person.
    /// </summary>
    public sealed class RentVehicleUseCase : IRentVehicleUseCase
    {
        private static readonly VehicleRentableSpecification VehicleRentableSpecification = new();

        private readonly IVehicleRepository _vehicleRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        private readonly IRentVehicleOutputPort _outputPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        /// <param name="rentalRepository">Rental repository.</param>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="domainEventDispatcher">Domain event dispatcher.</param>
        /// <param name="outputPort">Output port.</param>
        public RentVehicleUseCase(
            IVehicleRepository vehicleRepository,
            IRentalRepository rentalRepository,
            IUnitOfWork unitOfWork,
            IDomainEventDispatcher domainEventDispatcher,
            IRentVehicleOutputPort outputPort)
        {
            _vehicleRepository = vehicleRepository;
            _rentalRepository = rentalRepository;
            _unitOfWork = unitOfWork;
            _domainEventDispatcher = domainEventDispatcher;
            _outputPort = outputPort;
        }

        /// <inheritdoc />
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = new VehicleId(input.VehicleId);
            var personId = new PersonId(input.PersonId);

            var vehicle = await _vehicleRepository.GetById(vehicleId);
            if (vehicle == null)
            {
                _outputPort.NotFoundHandle("Vehicle was not found.");
                return;
            }

            if (!VehicleRentableSpecification.IsSatisfiedBy(vehicle))
            {
                throw new DomainException("Vehicle is not available for rent.");
            }

            var currentRental = await _rentalRepository.GetActiveByPersonId(personId);
            if (currentRental != null)
            {
                throw new ActiveRentalAlreadyExistsException(personId);
            }

            var activeRentalForVehicle = await _rentalRepository.GetActiveByVehicleId(vehicleId);
            if (activeRentalForVehicle != null)
            {
                throw new DomainException("Vehicle already has an active rental.");
            }

            var rental = Rental.StartNew(RentalId.CreateNew(), vehicleId, personId, DateTime.UtcNow);

            vehicle.MarkAsRented();

            await _rentalRepository.Add(rental);
            await _vehicleRepository.Update(vehicle);
            await _unitOfWork.Save();
            await _domainEventDispatcher.DispatchAndClear([rental, vehicle]);

            _outputPort.StandardHandle(
                new RentVehicleOutput(
                    rental.Id.Value,
                    rental.VehicleId.Value,
                    rental.PersonId.Value,
                    rental.StartDateUtc));
        }
    }
}
