namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle
{
    /// <summary>
    /// Vehicle license plate value object.
    /// </summary>
    public readonly struct LicensePlate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlate"/> struct.
        /// </summary>
        /// <param name="licensePlate">Vehicle license plate.</param>
        public LicensePlate(string licensePlate)
        {
            if (string.IsNullOrEmpty(licensePlate))
            {
                throw new DomainException("License plate can't be null or empty.");
            }

            LicensePlateNumber = licensePlate;
        }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        public string LicensePlateNumber { get; }
    }
}
