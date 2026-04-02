using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Input for the create vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleInput"/> class.
    /// </remarks>
    /// <param name="licensePlate">License plate of the vehicle.</param>
    /// <param name="manufacturingDate">Manufacturing date of the vehicle.</param>
    /// <param name="model">Model of the vehicle.</param>
    public class CreateVehicleInput(string licensePlate, DateTime? manufacturingDate, string model) : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the license plate.
        /// </summary>
        public string LicensePlate { get; set; } = licensePlate;

        /// <summary>
        /// Gets or sets the manufacturing date.
        /// </summary>
        public DateTime? ManufacturingDate { get; set; } = manufacturingDate;

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public string Model { get; set; } = model;
    }
}
