using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle
{
    public class CreateVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public DateTime? ManufacturingDate { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
