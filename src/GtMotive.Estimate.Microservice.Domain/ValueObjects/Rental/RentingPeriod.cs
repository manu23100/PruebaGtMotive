using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental
{
    /// <summary>
    /// Period of the renting.
    /// </summary>
    public readonly struct RentingPeriod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentingPeriod"/> struct.
        /// </summary>
        /// <param name="startDate">Start date of the period.</param>
        /// <param name="endDate">End date of the period.</param>s
        /// <exception cref="InvalidRentingPeriodException">Throws if the period is invalid.</exception>
        public RentingPeriod(DateOnly startDate, DateOnly endDate)
        {
            if (startDate > endDate)
            {
                throw new InvalidRentingPeriodException($"The renting period is invalid. Start date {startDate} is greater than end date: {endDate}.");
            }

            if (startDate < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new InvalidRentingPeriodException($"Start date {startDate} can't be in the past.");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Gets the start date of the reting period.
        /// </summary>
        public DateOnly StartDate { get; }

        /// <summary>
        /// Gets the end date of the renting period.
        /// </summary>
        public DateOnly EndDate { get; }

        /// <summary>
        /// Gets number of days of the renting period.
        /// </summary>
        public readonly int NumberOfDays => EndDate.DayNumber - StartDate.DayNumber;
    }
}
