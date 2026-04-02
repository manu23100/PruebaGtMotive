using System;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Vehicle entity configuration.
    /// </summary>
    public sealed class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<VehicleEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(id => id.Id, guid => new VehicleId(guid))
                .IsRequired();

            builder.Property(v => v.LicensePlate)
                .HasConversion(lp => lp.LicensePlateNumber, s => new LicensePlate(s))
                .IsRequired();

            builder.Property(v => v.ManufacturingDate)
                .HasConversion(md => md.Date, d => new ManufacturingDate(d))
                .IsRequired();

            builder.Property(v => v.Model)
                .HasConversion(m => m.VehicleModel, s => new Model(s))
                .IsRequired();

            builder.Property(v => v.Status)
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
