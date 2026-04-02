using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Implementation of the <see cref="Rental"/> domain entity.
    /// </summary>
    /// <param name="rentalId">Rental identifier.</param>
    /// <param name="userId">User identifier.</param>
    /// <param name="vehicleId">Vehicle identifier.</param>
    /// <param name="rentingPeriod">Renting period.</param>
    /// <param name="rentingPrice">Renting price.</param>
    public sealed class RentalEntity(
        RentalId rentalId,
        UserId userId,
        VehicleId vehicleId,
        RentingPeriod rentingPeriod,
        Price rentingPrice) : Rental(rentalId, userId, vehicleId, rentingPeriod, rentingPrice)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentalEntity"/> class.
        /// </summary>
        private RentalEntity()
            : this(default, default, default, default, default)
        {
        }
    }
}
