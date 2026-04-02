namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception when the currency is invalid.
    /// </summary>
    public class InvalidCurrencyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InvalidCurrencyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public InvalidCurrencyException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCurrencyException"/> class.
        /// </summary>
        public InvalidCurrencyException()
            : base("The currency provided is invalid.")
        {
        }
    }
}
