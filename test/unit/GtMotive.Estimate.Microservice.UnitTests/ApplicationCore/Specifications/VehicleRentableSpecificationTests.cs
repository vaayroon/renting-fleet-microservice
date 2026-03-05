using System;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Domain.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Vehicles.Specifications;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore.Specifications
{
    /// <summary>
    /// Unit tests for <see cref="VehicleRentableSpecification"/>.
    /// </summary>
    public sealed class VehicleRentableSpecificationTests
    {
        [Fact]
        public void IsSatisfiedByWhenVehicleIsAvailableShouldReturnTrue()
        {
            var vehicle = Vehicle.Rehydrate(
                VehicleId.CreateNew(),
                new LicensePlate("1234-ABC"),
                DateTime.UtcNow.AddYears(-1),
                VehicleStatus.Available);

            var specification = new VehicleRentableSpecification();

            specification.IsSatisfiedBy(vehicle).Should().BeTrue();
        }

        [Fact]
        public void IsSatisfiedByWhenVehicleIsRentedShouldReturnFalse()
        {
            var vehicle = Vehicle.Rehydrate(
                VehicleId.CreateNew(),
                new LicensePlate("5678-DEF"),
                DateTime.UtcNow.AddYears(-1),
                VehicleStatus.Rented);

            var specification = new VehicleRentableSpecification();

            specification.IsSatisfiedBy(vehicle).Should().BeFalse();
        }
    }
}
