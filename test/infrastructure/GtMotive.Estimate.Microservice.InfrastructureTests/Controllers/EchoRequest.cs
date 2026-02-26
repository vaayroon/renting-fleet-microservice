using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Controllers
{
    /// <summary>
    /// Echo request payload.
    /// </summary>
    public sealed class EchoRequest
    {
        /// <summary>
        /// Gets or sets plate value.
        /// </summary>
        [Required]
        public string Plate { get; set; }

        /// <summary>
        /// Gets or sets person identifier.
        /// </summary>
        [Required]
        public string PersonId { get; set; }
    }
}
