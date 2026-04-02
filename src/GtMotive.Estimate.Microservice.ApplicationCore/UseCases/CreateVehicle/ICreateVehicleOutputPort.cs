namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Output port for the Create Vehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort
    {
        /// <summary>
        /// Handles the successful creation of a vehicle.
        /// </summary>
        /// <param name="output">Use case output.</param>
        void StandardHandle(CreateVehicleOutput output);
    }
}
