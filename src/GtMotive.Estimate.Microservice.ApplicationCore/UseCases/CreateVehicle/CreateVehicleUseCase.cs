using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle
{
    /// <summary>
    /// Create vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="CreateVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">Presenter that handles the use case output.</param>
    /// <param name="vehicleRepository">Repository used to persist the vehicle.</param>
    /// <param name="unitOfWork">Unit of Work that commits changes to the database.</param>
    /// <param name="vehicleFactory">Factory used to create the vehicle entity.</param>
    public class CreateVehicleUseCase(
        ICreateVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IUnitOfWork unitOfWork,
        IVehicleFactory vehicleFactory) : ICreateVehicleUseCase
    {
        private readonly ICreateVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IVehicleFactory _vehicleFactory = vehicleFactory;

        /// <inheritdoc/>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = new VehicleId(Guid.NewGuid());
            var licensePlate = new LicensePlate(input.LicensePlate);
            var manufacturingDate = new ManufacturingDate(input.ManufacturingDate.Value);
            var model = new Model(input.Model);

            var vehicle = _vehicleFactory.NewVehicle(vehicleId, licensePlate, manufacturingDate, model);

            _vehicleRepository.Add(vehicle);
            await _unitOfWork.Save();

            var output = new CreateVehicleOutput
            {
                VehicleId = vehicle.Id.Id,
                Status = vehicle.Status,
            };

            _outputPort.StandardHandle(output);
        }
    }
}
