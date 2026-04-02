using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception for an invalid renting period.
    /// </summary>
    public class InvalidRentingPeriodException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRentingPeriodException"/> class.
        /// </summary>
        public InvalidRentingPeriodException()
            : base("The renting period is invalid.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRentingPeriodException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidRentingPeriodException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRentingPeriodException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidRentingPeriodException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
