namespace GtMotive.Estimate.Microservice.Domain.Specifications;

/// <summary>
/// Represents a reusable business rule over a candidate instance.
/// </summary>
/// <typeparam name="T">Candidate type.</typeparam>
public interface ISpecification<in T>
{
    /// <summary>
    /// Evaluates whether the candidate satisfies the rule.
    /// </summary>
    /// <param name="candidate">Candidate instance to validate.</param>
    /// <returns>True when candidate satisfies the rule; otherwise false.</returns>
    bool IsSatisfiedBy(T candidate);
}
