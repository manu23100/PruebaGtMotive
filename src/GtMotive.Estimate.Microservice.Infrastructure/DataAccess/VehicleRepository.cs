using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// EF implementation of <see cref="IVehicleRepository"/>.
    /// </summary>
    public sealed class VehicleRepository(SqlDbContext context) : IVehicleRepository
    {
        /// <inheritdoc/>
        public void Add(IVehicle vehicle)
        {
            context.Vehicles.Add((VehicleEntity)vehicle);
        }

        /// <inheritdoc/>
        public async Task<List<IVehicle>> GetAll()
        {
            var vehicles = await context.Vehicles.ToListAsync();
            var result = new List<IVehicle>(vehicles.Count);
            result.AddRange(vehicles);
            return result;
        }

        /// <inheritdoc/>
        public async Task<IVehicle> GetById(VehicleId vehicleId)
        {
            return await context.Vehicles
                .SingleOrDefaultAsync(v => v.Id == vehicleId);
        }

        /// <inheritdoc/>
        public void UpdateStatus(IVehicle vehicle)
        {
            context.Entry((VehicleEntity)vehicle).Property(v => v.Status).IsModified = true;
        }
    }
}
