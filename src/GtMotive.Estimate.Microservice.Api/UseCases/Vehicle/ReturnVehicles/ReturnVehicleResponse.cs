namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles
{
    /// <summary>
    /// API response for the return vehicle endpoint.
    /// </summary>
    public class ReturnVehicleResponse
    {
        /// <summary>
        /// Gets or sets the vehicle status after the return.
        /// </summary>
        public string VehicleStatus { get; set; }

        /// <summary>
        /// Gets or sets the rental status after the return.
        /// </summary>
        public string RentalStatus { get; set; }
    }
}
