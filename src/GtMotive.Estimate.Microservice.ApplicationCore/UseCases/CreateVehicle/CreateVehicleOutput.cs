using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Output for the create vehicle use case.
    /// </summary>
    public class CreateVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the id of the vehicle.
        /// </summary>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the status of the vehicle.
        /// </summary>
        public VehicleStatus Status { get; set; }
    }
}
