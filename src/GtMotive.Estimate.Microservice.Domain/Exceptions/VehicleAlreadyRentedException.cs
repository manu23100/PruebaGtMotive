using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception for vehicles that are rented.
    /// </summary>
    public class VehicleAlreadyRentedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        public VehicleAlreadyRentedException()
            : base("The vehicle is already rented.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public VehicleAlreadyRentedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleAlreadyRentedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public VehicleAlreadyRentedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
