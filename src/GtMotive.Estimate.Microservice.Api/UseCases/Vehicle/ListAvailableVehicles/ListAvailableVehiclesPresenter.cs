using System;
using System.Linq;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ListAvailableVehicles
{
    public class ListAvailableVehiclesPresenter : IListAvailableVehiclesOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAvailableVehiclesOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var response = output.Vehicles.Select(v => new ListAvailableVehiclesResponse
            {
                LicensePlate = v.LicensePlate,
                Model = v.Model,
                ManufacturingDate = v.ManufacturingDate,
            }).ToList();

            ActionResult = new OkObjectResult(response);
        }
    }
}
