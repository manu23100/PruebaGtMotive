using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles
{
    public class ReturnVehiclePresenter : IReturnVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ReturnVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new ReturnVehicleResponse
            {
                VehicleStatus = output.VehicleStatus,
                RentalStatus = output.RentalStatus,
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
