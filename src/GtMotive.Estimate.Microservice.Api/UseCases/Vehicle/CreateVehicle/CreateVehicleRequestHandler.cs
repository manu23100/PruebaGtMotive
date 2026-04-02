using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle
{
    public class CreateVehicleRequestHandler(ICreateVehicleUseCase useCase, CreateVehiclePresenter presenter) : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private ICreateVehicleUseCase UseCase { get; set; } = useCase;

        private CreateVehiclePresenter Presenter { get; set; } = presenter;

        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new CreateVehicleInput(request.LicensePlate, request.ManufacturingDate, request.Model);

            await UseCase.Execute(input);

            return Presenter;
        }
    }
}
