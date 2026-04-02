using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Rental
{
    /// <summary>
    /// Factory port for creating Rental entities.
    /// </summary>
    public interface IRentalFactory
    {
        /// <summary>
        /// Creates a new rental entity.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="rentingPeriod">Renting period.</param>
        /// <param name="rentingPrice">Renting price.</param>
        /// <returns>A new rental.</returns>
        IRental NewRental(RentalId rentalId, UserId userId, VehicleId vehicleId, RentingPeriod rentingPeriod, Price rentingPrice);
    }
}
