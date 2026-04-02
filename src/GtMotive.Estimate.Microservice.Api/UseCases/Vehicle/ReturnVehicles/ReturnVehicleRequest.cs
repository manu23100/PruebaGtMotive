using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles
{
    public class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public Guid? VehicleId { get; set; }
    }
}
