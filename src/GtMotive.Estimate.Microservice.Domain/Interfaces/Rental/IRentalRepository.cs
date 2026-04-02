using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Rental
{
    /// <summary>
    /// Repository port for the rental.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Adds a new rental.
        /// </summary>
        /// <param name="rental">The rental to add.</param>
        void Add(IRental rental);

        /// <summary>
        /// Gets the active rental for a given user, or null if none exists.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The active <see cref="IRental"/> or null.</returns>
        Task<IRental> GetActiveRentalsByUser(UserId userId);

        /// <summary>
        /// Gets the active rental for a given vehicle, or null if none exists.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>The active <see cref="IRental"/> or null.</returns>
        Task<IRental> GetByVehicleId(VehicleId vehicleId);

        /// <summary>
        /// Updates only the status of an existing rental.
        /// </summary>
        /// <param name="rental">Rental whose status will be persisted.</param>
        void UpdateStatus(IRental rental);
    }
}
