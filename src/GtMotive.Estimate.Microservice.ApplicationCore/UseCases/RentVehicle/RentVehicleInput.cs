using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Input for the rent vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
    /// </remarks>
    /// <param name="userId">User identifier.</param>
    /// <param name="vehicleId">Vehicle identifier.</param>
    /// <param name="startDate">Start date of the rental.</param>
    /// <param name="endDate">End date of the rental.</param>
    public class RentVehicleInput(string userId, Guid? vehicleId, DateOnly? startDate, DateOnly? endDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public string UserId { get; set; } = userId;

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        public Guid? VehicleId { get; set; } = vehicleId;

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateOnly? StartDate { get; set; } = startDate;

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateOnly? EndDate { get; set; } = endDate;
    }
}
