using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle
{
    public class RentVehiclePresenter : IRentVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(RentVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new RentVehicleResponse
            {
                StartDate = output.StartDate,
                EndDate = output.EndDate,
                Amount = output.Amount,
                Currency = output.Currency,
            };

            ActionResult = new OkObjectResult(response);
        }

        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        public void HasConflictHandle(string message)
        {
            ActionResult = new ConflictObjectResult(message);
        }
    }
}
