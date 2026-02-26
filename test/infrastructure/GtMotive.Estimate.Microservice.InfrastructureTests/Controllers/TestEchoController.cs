using System;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Controllers
{
    /// <summary>
    /// Test-only controller to validate host-level request binding.
    /// </summary>
    [ApiController]
    [Route("infra/echo")]
    public sealed class TestEchoController : ControllerBase
    {
        /// <summary>
        /// Receives a payload and returns no content when binding is successful.
        /// </summary>
        /// <param name="request">Input payload.</param>
        /// <returns>No content response.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] EchoRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            return NoContent();
        }
    }
}
