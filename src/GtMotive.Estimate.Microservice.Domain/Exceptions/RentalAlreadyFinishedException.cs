namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception for a finshed rental.
    /// </summary>
    public class RentalAlreadyFinishedException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyFinishedException"/> class.
        /// </summary>
        public RentalAlreadyFinishedException()
            : base("Rental is already finished.")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyFinishedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public RentalAlreadyFinishedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalAlreadyFinishedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public RentalAlreadyFinishedException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
