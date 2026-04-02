namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Output port for the Rent Vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort
    {
        /// <summary>
        /// Handles the successful rental of a vehicle.
        /// </summary>
        /// <param name="output">Use case output.</param>
        void StandardHandle(RentVehicleOutput output);

        /// <summary>
        /// Handles the case where the requested resource was not found.
        /// </summary>
        /// <param name="message">Description of what was not found.</param>
        void NotFoundHandle(string message);

        /// <summary>
        /// Handles a conflict that prevents the rental from completing.
        /// </summary>
        /// <param name="message">Description of the conflict.</param>
        void HasConflictHandle(string message);
    }
}
