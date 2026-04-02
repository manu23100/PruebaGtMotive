using System;
using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;

namespace GtMotive.Estimate.Microservice.Domain.Services
{
    /// <summary>
    /// Domain service for calculate the price of the rental.
    /// </summary>
    public static class RentingPriceDomainService
    {
        private const decimal DEFAULTDAILYRATE = 55m;

        private static readonly Dictionary<string, decimal> _dailyRates = new()
        {
            { "sedan", 50m },
            { "suv", 75m },
            { "coupe", 90m },
            { "cabrio", 85m },
            { "truck", 80m }
        };

        /// <summary>
        /// Calculate the price for the rental using the renting period and vehicle.
        /// </summary>
        /// <param name="rentingPeriod">Renting period.</param>
        /// <param name="vehicle">Vehicle information.</param>
        /// <returns>Price of the rental.</returns>
        public static Price Calculate(RentingPeriod rentingPeriod, IVehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            var dailyRate = GetDailyRate(vehicle.Model.VehicleModel);

            return new Price(
                dailyRate * rentingPeriod.NumberOfDays,
                "EUR");
        }

        /// <summary>
        /// Gets daily rate based on the vehicle model.
        /// </summary>
        /// <param name="model">Vehicle model.</param>
        /// <returns>Daily rate.</returns>
        private static decimal GetDailyRate(string model)
        {
            return _dailyRates.TryGetValue(model, out var value) ? value : DEFAULTDAILYRATE;
        }
    }
}
