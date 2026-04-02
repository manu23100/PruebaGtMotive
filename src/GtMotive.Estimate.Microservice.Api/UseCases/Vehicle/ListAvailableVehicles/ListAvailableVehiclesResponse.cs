using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ListAvailableVehicles
{
    /// <summary>
    /// Represents a single available vehicle in the API response.
    /// </summary>
    public class ListAvailableVehiclesResponse
    {
        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing date.
        /// </summary>
        public DateTime ManufacturingDate { get; set; }
    }
}
