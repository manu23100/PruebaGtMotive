using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception class for the manufacturing date.
    /// </summary>
    public class OldVehicleException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OldVehicleException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public OldVehicleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OldVehicleException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public OldVehicleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OldVehicleException"/> class.
        /// </summary>
        public OldVehicleException()
            : base("The vehicle is too old to be in the fleet.")
        {
        }
    }
}
