using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Immplementation of the <see cref="Vehicle"/> domain entity.
    /// </summary>
    /// <param name="vehicleId">Vehicle identifier.</param>
    /// <param name="licensePlate">Vehicle license plate.</param>
    /// <param name="manufacturingDate">Vehicle manufacturing date.</param>
    /// <param name="model">Vehicle model.</param>
    public sealed class VehicleEntity(
        VehicleId vehicleId,
        LicensePlate licensePlate,
        ManufacturingDate manufacturingDate,
        Model model) : Vehicle(vehicleId, licensePlate, manufacturingDate, model)
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleEntity"/> class.
        /// </summary>
        private VehicleEntity()
            : this(default, default, default, default)
        {
        }
    }
}
