using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rentals;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Unit tests for <see cref="RentVehicleUseCase"/>.
    /// </summary>
    public sealed class RentVehicleUseCaseTests
    {
        /// <summary>
        /// Ensures renting fails when person already has an active rental.
        /// </summary>
        /// <returns>Asynchronous task.</returns>
        [Fact]
        public async Task ExecuteWhenPersonAlreadyHasActiveRentalShouldThrowBusinessException()
        {
            var vehicleId = new VehicleId(Guid.NewGuid());
            var personId = new PersonId(Guid.NewGuid());

            var availableVehicle = Vehicle.Rehydrate(
                vehicleId,
                new LicensePlate("1234-ABC"),
                DateTime.UtcNow.AddYears(-2),
                VehicleStatus.Available);

            var activeRental = Rental.StartNew(RentalId.CreateNew(), vehicleId, personId, DateTime.UtcNow.AddDays(-1));

            var vehicleRepository = new Mock<IVehicleRepository>();
            var rentalRepository = new Mock<IRentalRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var outputPort = new Mock<IRentVehicleOutputPort>();

            vehicleRepository
                .Setup(repository => repository.GetById(vehicleId))
                .ReturnsAsync(availableVehicle);

            rentalRepository
                .Setup(repository => repository.GetActiveByPersonId(personId))
                .ReturnsAsync(activeRental);

            var useCase = new RentVehicleUseCase(
                vehicleRepository.Object,
                rentalRepository.Object,
                unitOfWork.Object,
                outputPort.Object);

            Func<Task> action = async () =>
                await useCase.Execute(new RentVehicleInput(vehicleId.Value, personId.Value));

            await action.Should().ThrowAsync<ActiveRentalAlreadyExistsException>();

            rentalRepository.Verify(repository => repository.Add(It.IsAny<Rental>()), Times.Never);
            vehicleRepository.Verify(repository => repository.Update(It.IsAny<Vehicle>()), Times.Never);
            unitOfWork.Verify(work => work.Save(), Times.Never);
        }
    }
}
