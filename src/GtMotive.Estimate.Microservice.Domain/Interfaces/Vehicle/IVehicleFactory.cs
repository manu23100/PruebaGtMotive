using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle
{
    /// <summary>
    /// Factory interface for creating vehicle entities.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="licensePlate">Vehicle license plate.</param>
        /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
        /// <param name="model">Vehicle model.</param>
        /// <returns>A new <see cref="IVehicle"/> instance.</returns>
        IVehicle NewVehicle(VehicleId vehicleId, LicensePlate licensePlate, ManufacturingDate manufacturingDate, Model model);
    }
}
