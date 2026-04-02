using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Custom exception for invalid vehicle model.
    /// </summary>
    public class ModelNotValidException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNotValidException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ModelNotValidException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNotValidException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public ModelNotValidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelNotValidException"/> class.
        /// </summary>
        public ModelNotValidException()
            : base("The vehicle model is not valid.")
        {
        }
    }
}
