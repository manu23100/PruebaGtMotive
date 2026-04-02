using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle
{
    public class CreateVehiclePresenter : ICreateVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CreateVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = new CreateVehicleResponse(output.VehicleId, output.Status.ToString());

            ActionResult = new CreatedAtActionResult("create", "vehicle", output.VehicleId, response);
        }
    }
}
