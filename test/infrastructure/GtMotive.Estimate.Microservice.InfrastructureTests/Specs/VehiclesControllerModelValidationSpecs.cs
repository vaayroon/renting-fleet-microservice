using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    /// <summary>
    /// Infrastructure tests for host-level request binding behavior.
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
        /// Validates host-level model binding receives and binds request payload.
        /// </summary>
        /// <returns>Asynchronous task.</returns>
        [Fact]
        public async Task PostEchoWhenPayloadIsValidShouldReturnNoContent()
        {
            using var client = Fixture.Server.CreateClient();
            var payload = new { plate = "1234-ABC", personId = "person-1" };
            using var content = JsonContent.Create(payload);

            using var response = await client.PostAsync(new System.Uri("/infra/echo", System.UriKind.Relative), content);

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
