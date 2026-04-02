using System;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// DbContext used by the app.
    /// </summary>
    public sealed class SqlDbContext(DbContextOptions<SqlDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the vehicles table.
        /// </summary>
        public DbSet<VehicleEntity> Vehicles { get; set; }

        /// <summary>
        /// Gets or sets the rentals table.
        /// </summary>
        public DbSet<RentalEntity> Rentals { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly);
        }
    }
}
