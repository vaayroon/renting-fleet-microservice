using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions;

/// <summary>
/// Exception thrown when a persistence unique constraint is violated.
/// </summary>
public sealed class UniqueConstraintViolationException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueConstraintViolationException"/> class.
    /// </summary>
    public UniqueConstraintViolationException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueConstraintViolationException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    public UniqueConstraintViolationException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UniqueConstraintViolationException"/> class.
    /// </summary>
    /// <param name="message">Exception message.</param>
    /// <param name="innerException">Inner exception.</param>
    public UniqueConstraintViolationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
