using GtMotive.Estimate.Microservice.Domain.Entities.Base;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </summary>
    /// <param name="rentalId">Rental id.</param>
    /// <param name="userId">User id.</param>
    /// <param name="vehicleId">Vehicle id.</param>
    /// <param name="rentingPeriod">Period of the rental.</param>
    /// <param name="rentingPrice">Price of the rental.</param>
    public abstract class Rental(RentalId rentalId, UserId userId, VehicleId vehicleId, RentingPeriod rentingPeriod, Price rentingPrice) : Entity<RentalId>(rentalId), IRental
    {
        /// <inheritdoc/>
        public UserId UserId { get; protected set; } = userId;

        /// <inheritdoc/>
        public VehicleId VehicleId { get; protected set; } = vehicleId;

        /// <inheritdoc/>
        public RentingPeriod RentingPeriod { get; protected set; } = rentingPeriod;

        /// <inheritdoc/>
        public Price RentingPrice { get; protected set; } = rentingPrice;

        /// <inheritdoc/>
        public RentalStatus Status { get; protected set; } = RentalStatus.Active;

        /// <inheritdoc/>
        public void Finish()
        {
            if (Status == RentalStatus.Complete)
            {
                throw new RentalAlreadyFinishedException($"Rental {Id} is already finished.");
            }

            Status = RentalStatus.Complete;
        }
    }
}
