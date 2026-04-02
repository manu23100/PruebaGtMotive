using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// EF implementation of <see cref="IRentalRepository"/>.
    /// </summary>
    public sealed class RentalRepository(SqlDbContext context) : IRentalRepository
    {
        /// <inheritdoc/>
        public void Add(IRental rental)
        {
            context.Rentals.Add((RentalEntity)rental);
        }

        /// <inheritdoc/>
        public async Task<IRental> GetActiveRentalsByUser(UserId userId)
        {
            return await context.Rentals
                .FirstOrDefaultAsync(r => r.UserId == userId && r.Status == RentalStatus.Active);
        }

        /// <inheritdoc/>
        public async Task<IRental> GetByVehicleId(VehicleId vehicleId)
        {
            return await context.Rentals
                .FirstOrDefaultAsync(r => r.VehicleId == vehicleId && r.Status == RentalStatus.Active);
        }

        /// <inheritdoc/>
        public void UpdateStatus(IRental rental)
        {
            context.Entry((RentalEntity)rental).Property(r => r.Status).IsModified = true;
        }
    }
}
