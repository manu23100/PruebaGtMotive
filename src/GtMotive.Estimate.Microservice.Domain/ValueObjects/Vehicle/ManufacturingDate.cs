using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle
{
    /// <summary>
    /// Manufacturing date value object.
    /// </summary>
    public readonly struct ManufacturingDate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturingDate"/> struct.
        /// </summary>
        /// <param name="date">Manufacturing date.</param>
        public ManufacturingDate(DateTime date)
        {
            if (date > DateTime.UtcNow)
            {
                throw new DomainException("Manufacturing date can't be older than now.");
            }

            if (date.AddYears(5) < DateTime.UtcNow)
            {
                throw new OldVehicleException();
            }

            Date = date;
        }

        /// <summary>
        /// Gets the manufacturing date.
        /// </summary>
        public DateTime Date { get; }
    }
}
