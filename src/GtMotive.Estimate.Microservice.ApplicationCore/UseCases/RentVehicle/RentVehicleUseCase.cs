using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Rental;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Services;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Rental;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental
{
    /// <summary>
    /// Rent vehicle use case.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
    /// </remarks>
    /// <param name="outputPort">Presenter that handles the use case output.</param>
    /// <param name="vehicleRepository">Repository used to retrieve vehicles.</param>
    /// <param name="rentalRepository">Repository used to persist the rental.</param>
    /// <param name="unitOfWork">Unit of Work that commits changes to the database.</param>
    /// <param name="rentalFactory">Factory used to create the rental entity.</param>
    public class RentVehicleUseCase(
        IRentVehicleOutputPort outputPort,
        IVehicleRepository vehicleRepository,
        IRentalRepository rentalRepository,
        IUnitOfWork unitOfWork,
        IRentalFactory rentalFactory) : IRentVehicleUseCase
    {
        private readonly IRentVehicleOutputPort _outputPort = outputPort;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IRentalFactory _rentalFactory = rentalFactory;

        /// <inheritdoc/>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicleId = new VehicleId(input.VehicleId.Value);

            var vehicle = await _vehicleRepository.GetById(vehicleId);

            if (vehicle is null)
            {
                _outputPort.NotFoundHandle($"Vehicle not found.");
                return;
            }

            var userId = new UserId(input.UserId);

            var existingRental = await _rentalRepository.GetActiveRentalsByUser(userId);

            if (existingRental != null)
            {
                _outputPort.HasConflictHandle($"User '{input.UserId}' already has an active rental.");
                return;
            }

            var rentingPeriod = new RentingPeriod(input.StartDate.Value, input.EndDate.Value);
            var price = RentingPriceDomainService.Calculate(rentingPeriod, vehicle);

            var rentalId = new RentalId(Guid.NewGuid());
            var rental = _rentalFactory.NewRental(rentalId, userId, vehicleId, rentingPeriod, price);

            try
            {
                vehicle.Rent();
            }
            catch (VehicleAlreadyRentedException ex)
            {
                _outputPort.HasConflictHandle(ex.Message);
                return;
            }

            _vehicleRepository.UpdateStatus(vehicle);
            _rentalRepository.Add(rental);
            await _unitOfWork.Save();

            var output = new RentVehicleOutput
            {
                StartDate = rentingPeriod.StartDate,
                EndDate = rentingPeriod.EndDate,
                Amount = price.Amount,
                Currency = price.Currency,
            };

            _outputPort.StandardHandle(output);
        }
    }
}
