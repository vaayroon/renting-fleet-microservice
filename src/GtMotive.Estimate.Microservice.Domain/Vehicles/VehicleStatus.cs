namespace GtMotive.Estimate.Microservice.Domain.Vehicles;

/// <summary>
/// Vehicle availability state.
/// </summary>
public enum VehicleStatus
{
    /// <summary>
    /// Vehicle can be rented.
    /// </summary>
    Available = 0,

    /// <summary>
    /// Vehicle is currently rented.
    /// </summary>
    Rented = 1,
}
