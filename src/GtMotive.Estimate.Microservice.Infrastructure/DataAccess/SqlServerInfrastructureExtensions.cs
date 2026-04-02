using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Infrastructure.DataAccess
{
    /// <summary>
    /// Extension methods to register SQL Server infrastructure services.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class SqlServerInfrastructureExtensions
    {
        /// <summary>
        /// Registers DbContext, Unit of Work, repositories and factories.
        /// </summary>
        /// <param name="builder">Infrastructure builder.</param>
        /// <param name="configuration">Application configuration (used to resolve the connection string).</param>
        /// <returns>The same <see cref="IInfrastructureBuilder"/> for chaining.</returns>
        public static IInfrastructureBuilder AddSqlServerInfrastructure(
            this IInfrastructureBuilder builder,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(builder);

            var connectionString = configuration.GetConnectionString("SqlServer");

            builder.Services.AddDbContext<SqlDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null)));

            builder.Services.AddScoped<IUnitOfWork, SqlServerUnitOfWork>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddScoped<IVehicleFactory, EntityFactory>();
            builder.Services.AddScoped<IRentalRepository, RentalRepository>();
            builder.Services.AddScoped<IRentalFactory, EntityFactory>();

            return builder;
        }
    }
}
