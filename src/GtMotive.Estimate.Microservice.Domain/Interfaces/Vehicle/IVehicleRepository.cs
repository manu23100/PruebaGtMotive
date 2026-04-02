using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle
{
    /// <summary>
    /// Interface for the vehicle repository.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle to add.</param>
        void Add(IVehicle vehicle);

        /// <summary>
        /// Returns all vehicles.
        /// </summary>
        /// <returns>All available vehicles.</returns>
        Task<List<IVehicle>> GetAll();

        /// <summary>
        /// Gets a vehicle by id.
        /// </summary>
        /// <param name="vehicleId">Vehicle id.</param>
        /// <returns>Vehicle that matches the id, or null if not found.</returns>
        Task<IVehicle> GetById(VehicleId vehicleId);

        /// <summary>
        /// Updates only the status of an existing vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle whose status will be persisted.</param>
        void UpdateStatus(IVehicle vehicle);
    }
}
