using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles
{
    public class ReturnVehicleRequestHandler(IReturnVehicleUseCase useCase, ReturnVehiclePresenter presenter) : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private IReturnVehicleUseCase UseCase { get; set; } = useCase;

        private ReturnVehiclePresenter Presenter { get; set; } = presenter;

        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new ReturnVehicleInput(request.VehicleId);

            await UseCase.Execute(input);

            return Presenter;
        }
    }
}
