using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental
{
    /// <summary>
    /// Rental value object.
    /// </summary>
    public readonly struct RentalId
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalId"/> struct.
        /// </summary>
        /// <param name="id">Rental id.</param>
        public RentalId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new ArgumentException("Rental id can not be empty", nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Gets the rental id.
        /// </summary>
        public Guid Id { get; }
    }
}
