namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle
{
    /// <summary>
    /// Status of a rental.
    /// </summary>
    public enum VehicleStatus
    {
        /// <summary>
        /// The vehicle is already rented.
        /// </summary>
        Rented,

        /// <summary>
        /// The vehicle is available to rent.
        /// </summary>
        Available
    }
}
