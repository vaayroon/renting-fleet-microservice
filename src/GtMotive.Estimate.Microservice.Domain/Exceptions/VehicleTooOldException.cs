using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions;

/// <summary>
/// Exception thrown when vehicle manufacture date exceeds allowed age.
/// </summary>
public sealed class VehicleTooOldException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
    /// </summary>
    public VehicleTooOldException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public VehicleTooOldException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public VehicleTooOldException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleTooOldException"/> class.
    /// </summary>
    /// <param name="manufactureDate">Vehicle manufacture date.</param>
    public VehicleTooOldException(DateTime manufactureDate)
        : base($"Vehicle manufacture date '{manufactureDate:yyyy-MM-dd}' is older than 5 years.")
    {
    }
}
