using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Return vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ReturnVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">Presenter that handles the use case output.</param>
    /// <param name="vehicleRepository">Repository used to retrieve and update vehicles.</param>
    /// <param name="rentalRepository">Repository used to retrieve and update rentals.</param>
    /// <param name="unitOfWork">Unit of Work that commits changes to the database.</param>
    public class ReturnVehicleUseCase(
        IReturnVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork) : IReturnVehicleUseCase
    {
        private readonly IReturnVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        /// <inheritdoc/>
        public async Task Execute(ReturnVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = new VehicleId(input.VehicleId.Value);

            var vehicle = await _vehicleRepository.GetById(vehicleId);

            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle not found.");
                return;
            }

            var rental = await _rentalRepository.GetByVehicleId(vehicleId);

            if (rental is null)
            {
                _outputPort.NotFoundHandle($"No active rental found for vehicle with license plate '{vehicle.LicensePlate.LicensePlateNumber}'.");
                return;
            }

            try
            {
                rental.Finish();
            }
            catch (RentalAlreadyFinishedException ex)
            {
                _outputPort.HasConflictHandle(ex.Message);
                return;
            }

            _rentalRepository.UpdateStatus(rental);

            try
            {
                vehicle.ReturnVehicle();
            }
            catch (VehicleNotRentedException ex)
            {
                _outputPort.HasConflictHandle(ex.Message);
                return;
            }

            _vehicleRepository.UpdateStatus(vehicle);
            await _unitOfWork.Save();

            var output = new ReturnVehicleOutput
            {
                VehicleStatus = vehicle.Status.ToString(),
                RentalStatus = rental.Status.ToString(),
            };

            _outputPort.StandardHandle(output);
        }
    }
}
