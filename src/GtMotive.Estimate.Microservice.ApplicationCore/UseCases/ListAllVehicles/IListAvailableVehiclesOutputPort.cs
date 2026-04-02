namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Output port for the List Available Vehicles use case.
    /// </summary>
    public interface IListAvailableVehiclesOutputPort
    {
        /// <summary>
        /// Handles the successful retrieval of available vehicles.
        /// </summary>
        /// <param name="output">Use case output.</param>
        void StandardHandle(ListAvailableVehiclesOutput output);
    }
}
