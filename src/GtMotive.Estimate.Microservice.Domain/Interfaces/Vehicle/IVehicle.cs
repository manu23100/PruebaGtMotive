using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle
{
    /// <summary>
    /// Interface representing the vehicle.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        VehicleId Id { get; }

        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        LicensePlate LicensePlate { get; }

        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        ManufacturingDate ManufacturingDate { get; }

        /// <summary>
        /// Gets the vehicle id.
        /// </summary>
        VehicleStatus Status { get; }

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        Model Model { get; }

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        void Rent();

        /// <summary>
        /// Return a vehicle.
        /// </summary>
        void ReturnVehicle();
    }
}
