using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle
{
    public class RentVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public Guid? VehicleId { get; set; }

        [Required]
        public DateOnly? StartDate { get; set; }

        [Required]
        public DateOnly? EndDate { get; set; }
    }
}
