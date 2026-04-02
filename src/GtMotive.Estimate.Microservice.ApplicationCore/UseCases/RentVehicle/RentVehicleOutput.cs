using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Output for the rent vehicle use case.
    /// </summary>
    public class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        public DateOnly EndDate { get; set; }

        /// <summary>
        /// Gets or sets the rental price amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the rental price currency.
        /// </summary>
        public string Currency { get; set; }
    }
}
