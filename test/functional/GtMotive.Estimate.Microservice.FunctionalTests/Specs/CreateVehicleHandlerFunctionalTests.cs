using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    /// <summary>
    /// Functional tests for create vehicle handler flow without host.
    /// </summary>
    public sealed class CreateVehicleHandlerFunctionalTests
    {
        /// <summary>
        /// Ensures request handler executes use case and returns created response.
        /// </summary>
        /// <returns>Asynchronous task.</returns>
        [Fact]
        public async Task HandleWhenRequestIsValidShouldReturnCreatedResult()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IVehicleRepository, InMemoryVehicleRepository>();
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(provider => provider.GetRequiredService<CreateVehiclePresenter>());
            services.AddScoped<ICreateVehicleUseCase, CreateVehicleUseCase>();
            services.AddScoped<IRequestHandler<CreateVehicleRequest, IWebApiPresenter>, CreateVehicleRequestHandler>();

            await using var serviceProvider = services.BuildServiceProvider();
            await using var scope = serviceProvider.CreateAsyncScope();

            var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<CreateVehicleRequest, IWebApiPresenter>>();

            var request = new CreateVehicleRequest
            {
                Plate = "5678-BCD",
                ManufactureDate = DateTime.UtcNow.AddYears(-1),
            };

            var presenter = await handler.Handle(request, CancellationToken.None);

            presenter.ActionResult.Should().BeOfType<CreatedResult>();

            var createdResult = (CreatedResult)presenter.ActionResult;
            createdResult.Value.Should().BeOfType<CreateVehicleResponse>();

            var response = (CreateVehicleResponse)createdResult.Value;
            response.Plate.Should().Be("5678-BCD");

            var repository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
            var inMemoryRepository = repository as InMemoryVehicleRepository;
            inMemoryRepository.Should().NotBeNull();
            inMemoryRepository.StoredVehicles.Should().ContainSingle();
        }

        private sealed class FakeUnitOfWork : IUnitOfWork
        {
            public Task<int> Save()
            {
                return Task.FromResult(1);
            }
        }

        private sealed class InMemoryVehicleRepository : IVehicleRepository
        {
            public List<Vehicle> StoredVehicles { get; } = [];

            public Task Add(Vehicle vehicle)
            {
                StoredVehicles.Add(vehicle);
                return Task.CompletedTask;
            }

            public Task Update(Vehicle vehicle)
            {
                var index = StoredVehicles.ToList().FindIndex(existing => existing.Id == vehicle.Id);
                if (index >= 0)
                {
                    StoredVehicles[index] = vehicle;
                }

                return Task.CompletedTask;
            }

            public Task<Vehicle> GetById(VehicleId id)
            {
                return Task.FromResult(StoredVehicles.Find(vehicle => vehicle.Id == id));
            }

            public Task<IReadOnlyCollection<Vehicle>> GetAvailable()
            {
                var result = StoredVehicles.Where(vehicle => vehicle.IsAvailable).ToList();
                return Task.FromResult((IReadOnlyCollection<Vehicle>)result);
            }

            public Task<bool> ExistsByPlate(LicensePlate plate)
            {
                var exists = StoredVehicles.Exists(vehicle => vehicle.Plate.Equals(plate));
                return Task.FromResult(exists);
            }
        }
    }
}
