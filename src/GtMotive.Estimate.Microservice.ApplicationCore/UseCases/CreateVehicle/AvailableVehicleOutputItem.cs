using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Represents a single available vehicle in the output.
    /// </summary>
    public class AvailableVehicleOutputItem
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
