namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Output for the Return Vehicle use case.
    /// </summary>
    public class ReturnVehicleOutput : IUseCaseOutput
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
