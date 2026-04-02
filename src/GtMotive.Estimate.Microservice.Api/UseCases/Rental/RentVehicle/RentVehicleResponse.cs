using System;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle
{
    /// <summary>
    /// API response for the rent vehicle endpoint.
    /// </summary>
    public class RentVehicleResponse
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
