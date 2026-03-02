using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    /// <summary>
    /// Infrastructure tests for host-level request binding and model validation behavior.
    /// </summary>
    public sealed class VehiclesControllerModelValidationSpecs : InfrastructureTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesControllerModelValidationSpecs"/> class.
        /// </summary>
        /// <param name="fixture">Test server fixture.</param>
        public VehiclesControllerModelValidationSpecs(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
        }

        /// <summary>
        /// Validates host-level model validation for an implemented REST endpoint.
        /// </summary>
        /// <returns>Asynchronous task.</returns>
        [Fact]
        public async Task PostVehiclesWhenPlateIsMissingShouldReturnBadRequest()
        {
            using var client = Fixture.Server.CreateClient();
            var payload = new
            {
                manufactureDate = DateTime.UtcNow.AddYears(-1),
            };
            using var content = JsonContent.Create(payload);

            using var response = await client.PostAsync(new Uri("/api/vehicles", UriKind.Relative), content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
