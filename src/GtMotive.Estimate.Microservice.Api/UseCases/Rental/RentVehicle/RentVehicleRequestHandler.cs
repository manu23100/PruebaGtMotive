using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle
{
    public class RentVehicleRequestHandler(IRentVehicleUseCase useCase, RentVehiclePresenter presenter) : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private IRentVehicleUseCase UseCase { get; set; } = useCase;

        private RentVehiclePresenter Presenter { get; set; } = presenter;

        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new RentVehicleInput(request.UserId, request.VehicleId, request.StartDate, request.EndDate);

            await UseCase.Execute(input);

            return Presenter;
        }
    }
}
