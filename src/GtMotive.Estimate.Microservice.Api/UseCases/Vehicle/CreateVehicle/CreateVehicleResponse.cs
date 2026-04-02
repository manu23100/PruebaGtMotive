using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle
{
    public class CreateVehicleResponse(Guid vehicleId, string status)
    {
        /// <summary>
        /// Gets or sets the id of the vehicle.
        /// </summary>
        [Required]
        public Guid VehicleId { get; set; } = vehicleId;

        /// <summary>
        /// Gets or sets the status of the vehicle.
        /// </summary>
        [Required]
        public string Status { get; set; } = status;
    }
}
