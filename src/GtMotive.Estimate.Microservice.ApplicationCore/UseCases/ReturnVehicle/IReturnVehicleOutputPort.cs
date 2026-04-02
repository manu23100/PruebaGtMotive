namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Output port for the Return Vehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort
    {
        /// <summary>
        /// Handles the successful return of a vehicle.
        /// </summary>
        /// <param name="output">Use case output.</param>
        void StandardHandle(ReturnVehicleOutput output);

        /// <summary>
        /// Handles the case where the requested resource was not found.
        /// </summary>
        /// <param name="message">Description of what was not found.</param>
        void NotFoundHandle(string message);

        /// <summary>
        /// Handles a conflict that prevents the return from completing.
        /// </summary>
        /// <param name="message">Description of the conflict.</param>
        void HasConflictHandle(string message);
    }
}
