using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ListAvailableVehicles
{
    public class ListAvailableVehiclesRequestHandler(IListAvailableVehiclesUseCase useCase, ListAvailableVehiclesPresenter presenter) : IRequestHandler<ListAvailableVehiclesRequest, IWebApiPresenter>
    {
        private IListAvailableVehiclesUseCase UseCase { get; set; } = useCase;

        private ListAvailableVehiclesPresenter Presenter { get; set; } = presenter;

        public async Task<IWebApiPresenter> Handle(ListAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await UseCase.Execute(new ListAvailableVehiclesInput());

            return Presenter;
        }
    }
}
