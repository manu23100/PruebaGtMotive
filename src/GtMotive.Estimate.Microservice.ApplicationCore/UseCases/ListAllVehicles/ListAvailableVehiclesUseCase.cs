using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// List available vehicles use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ListAvailableVehiclesUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">Presenter that handles the use case output.</param>
    /// <param name="vehicleRepository">Repository used to retrieve vehicles.</param>
    public class ListAvailableVehiclesUseCase(
        IListAvailableVehiclesOutputPort outputPort,
        IVehicleRepository vehicleRepository) : IListAvailableVehiclesUseCase
    {
        private readonly IListAvailableVehiclesOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        /// <inheritdoc/>
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var allVehicles = await _vehicleRepository.GetAll();

            var availableVehicles = allVehicles
                .Where(v => v.Status == VehicleStatus.Available)
                .Select(v => new AvailableVehicleOutputItem
                {
                    LicensePlate = v.LicensePlate.LicensePlateNumber,
                    Model = v.Model.VehicleModel,
                    ManufacturingDate = v.ManufacturingDate.Date,
                })
                .ToList();

            var output = new ListAvailableVehiclesOutput { Vehicles = new ReadOnlyCollection<AvailableVehicleOutputItem>(availableVehicles) };
            _outputPort.StandardHandle(output);
        }
    }
}
