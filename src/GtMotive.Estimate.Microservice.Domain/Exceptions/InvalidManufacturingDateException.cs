using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception class for the manufacturing date.
    /// </summary>
    public class InvalidManufacturingDateException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidManufacturingDateException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidManufacturingDateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidManufacturingDateException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidManufacturingDateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidManufacturingDateException"/> class.
        /// </summary>
        public InvalidManufacturingDateException()
            : base("The manufacturing date is invalid.")
        {
        }
    }
}
