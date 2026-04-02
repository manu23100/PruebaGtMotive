using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Input for the Return Vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
    /// </remarks>
    /// <param name="vehicleId">Vehicle identifier.</param>
    public class ReturnVehicleInput(Guid? vehicleId) : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid? VehicleId { get; set; } = vehicleId;
    }
}
