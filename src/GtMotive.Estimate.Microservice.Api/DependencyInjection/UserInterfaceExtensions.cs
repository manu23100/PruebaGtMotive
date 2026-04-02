using GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ListAvailableVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    /// <summary>
    /// Extension methods to register presenter implementations.
    /// </summary>
    public static class UserInterfaceExtensions
    {
        /// <summary>
        /// Registers all used presenters.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<ICreateVehicleOutputPort>(
                sp => sp.GetRequiredService<CreateVehiclePresenter>());

            services.AddScoped<ListAvailableVehiclesPresenter>();
            services.AddScoped<IListAvailableVehiclesOutputPort>(
                sp => sp.GetRequiredService<ListAvailableVehiclesPresenter>());

            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<IRentVehicleOutputPort>(
                sp => sp.GetRequiredService<RentVehiclePresenter>());

            services.AddScoped<ReturnVehiclePresenter>();
            services.AddScoped<IReturnVehicleOutputPort>(
                sp => sp.GetRequiredService<ReturnVehiclePresenter>());

            return services;
        }
    }
}
