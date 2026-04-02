namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception when the amount is invalid.
    /// </summary>
    public class InvalidAmountException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAmountException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidAmountException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAmountException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidAmountException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidAmountException"/> class.
        /// </summary>
        public InvalidAmountException()
            : base("The amount provided is invalid.")
        {
        }
    }
}
