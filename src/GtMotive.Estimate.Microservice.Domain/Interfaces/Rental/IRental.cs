using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Rental
{
    /// <summary>
    /// Interface representing the rental.
    /// </summary>
    public interface IRental
    {
        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        RentalId Id { get; }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        VehicleId VehicleId { get; }

        /// <summary>
        /// Gets user which is going to rent the vehicle.
        /// </summary>
        UserId UserId { get; }

        /// <summary>
        /// Gets number of days the vehicles will be rented.
        /// </summary>
        RentingPeriod RentingPeriod { get; }

        /// <summary>
        /// Gets the total price of the renting.
        /// </summary>
        Price RentingPrice { get; }

        /// <summary>
        /// Gets the status of a rental.
        /// </summary>
        RentalStatus Status { get; }

        /// <summary>
        /// Finish the rental.
        /// </summary>
        void Finish();
    }
}
