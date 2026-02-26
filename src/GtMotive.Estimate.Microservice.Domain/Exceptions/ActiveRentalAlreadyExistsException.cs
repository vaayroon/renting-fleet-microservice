using System;
using GtMotive.Estimate.Microservice.Domain.Rentals;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions;

/// <summary>
/// Exception thrown when a person tries to rent with an active rental already open.
/// </summary>
public sealed class ActiveRentalAlreadyExistsException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveRentalAlreadyExistsException"/> class.
    /// </summary>
    public ActiveRentalAlreadyExistsException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveRentalAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public ActiveRentalAlreadyExistsException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveRentalAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public ActiveRentalAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ActiveRentalAlreadyExistsException"/> class.
    /// </summary>
    /// <param name="personId">Person identifier.</param>
    public ActiveRentalAlreadyExistsException(PersonId personId)
        : base($"Person '{personId}' already has an active rental.")
    {
    }
}
