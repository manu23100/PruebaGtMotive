using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Factory that creates domain entity instances.
    /// </summary>
    public sealed class EntityFactory : IVehicleFactory, IRentalFactory
    {
        /// <inheritdoc/>
        public IVehicle NewVehicle(
            VehicleId vehicleId,
            LicensePlate licensePlate,
            ManufacturingDate manufacturingDate,
            Model model)
        {
            return new VehicleEntity(vehicleId, licensePlate, manufacturingDate, model);
        }

        /// <inheritdoc/>
        public IRental NewRental(
            RentalId rentalId,
            UserId userId,
            VehicleId vehicleId,
            RentingPeriod rentingPeriod,
            Price rentingPrice)
        {
            return new RentalEntity(rentalId, userId, vehicleId, rentingPeriod, rentingPrice);
        }
    }
}
