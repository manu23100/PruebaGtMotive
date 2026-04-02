using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental
{
    /// <summary>
    /// Price value object.
    /// </summary>
    public readonly struct Price
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Price"/> struct.
        /// </summary>
        /// <param name="amount">Amount of the price.</param>
        /// <param name="currency">Currency of the price.</param>
        public Price(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new InvalidAmountException();
            }

            if (string.IsNullOrEmpty(currency))
            {
                throw new InvalidCurrencyException();
            }

            if (currency != "EUR")
            {
                throw new InvalidCurrencyException();
            }

            Amount = amount;
            Currency = currency;
        }

        /// <summary>
        /// Gets the amount of the price.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the currency of the price.
        /// </summary>
        public string Currency { get; }
    }
}
