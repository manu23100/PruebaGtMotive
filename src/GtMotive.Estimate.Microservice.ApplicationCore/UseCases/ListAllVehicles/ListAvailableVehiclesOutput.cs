using System.Collections.ObjectModel;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Output for the list available vehicles use case.
    /// </summary>
    public class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the list of available vehicles.
        /// </summary>
        public ReadOnlyCollection<AvailableVehicleOutputItem> Vehicles { get; set; }
    }
}
