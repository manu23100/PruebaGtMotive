using GtMotive.Estimate.Microservice.Domain.Entities.Base;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle entity that represents a vehicle in the fleet.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="Vehicle"/> class.
    /// </remarks>
    /// <param name="vehicleId">Vehicle id.</param>
    /// <param name="licensePlate">Vehicle license plate.</param>
    /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
    /// <param name="model">Vehicle model.</param>
    public abstract class Vehicle(VehicleId vehicleId, LicensePlate licensePlate, ManufacturingDate manufacturingDate, Model model) : Entity<VehicleId>(vehicleId), IVehicle
    {
        /// <summary>
        /// Gets or sets the vehicle license plate.
        /// </summary>
        public LicensePlate LicensePlate { get; protected set; } = licensePlate;

        /// <summary>
        /// Gets or sets the manufacturing date.
        /// </summary>
        public ManufacturingDate ManufacturingDate { get; protected set; } = manufacturingDate;

        /// <summary>
        /// Gets or sets the vehicle status.
        /// </summary>
        public VehicleStatus Status { get; protected set; } = VehicleStatus.Available;

        /// <summary>
        /// Gets or sets the vehicle model.
        /// </summary>
        public Model Model { get; protected set; } = model;

        /// <summary>
        /// Rent a vehicle.
        /// </summary>
        /// <exception cref="VehicleAlreadyRentedException">Throws if the vehicle to rent is already rented.</exception>
        public void Rent()
        {
            if (Status == VehicleStatus.Rented)
            {
                throw new VehicleAlreadyRentedException($"Can't rent the vehicle {LicensePlate.LicensePlateNumber}, it is already rented.");
            }

            Status = VehicleStatus.Rented;
        }

        /// <summary>
        /// Return a rented vehicle.
        /// </summary>
        /// <exception cref="VehicleNotRentedException">Throws if a vehicle can't be returned.</exception>
        public void ReturnVehicle()
        {
            if (Status == VehicleStatus.Available)
            {
                throw new VehicleNotRentedException($"Can't return the vehicle {LicensePlate.LicensePlateNumber}, it is not rented.");
            }

            Status = VehicleStatus.Available;
        }
    }
}
