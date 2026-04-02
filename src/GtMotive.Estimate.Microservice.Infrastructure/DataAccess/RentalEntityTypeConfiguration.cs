using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Rental entity configuration.
    /// </summary>
    public sealed class RentalEntityTypeConfiguration : IEntityTypeConfiguration<RentalEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<RentalEntity> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("Rentals");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasConversion(id => id.Id, guid => new RentalId(guid))
                .IsRequired();

            builder.Property(r => r.UserId)
                .HasConversion(u => u.Id, s => new UserId(s))
                .IsRequired();

            builder.Property(r => r.VehicleId)
                .HasConversion(v => v.Id, guid => new VehicleId(guid))
                .IsRequired();

            builder.ComplexProperty(r => r.RentingPeriod, rp =>
            {
                rp.Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
                rp.Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
            });

            builder.ComplexProperty(r => r.RentingPrice, p =>
            {
                p.Property(x => x.Amount).HasColumnName("Amount").IsRequired();
                p.Property(x => x.Currency).HasColumnName("Currency").IsRequired();
            });

            builder.Property(r => r.Status)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
