using System;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    [Collection(TestCollections.Functional)]
    public sealed class CreateVehicleFunctionalTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task CreateVehicleWithValidDataShouldReturnCreatedResult()
        {
            // Arrange
            var request = new CreateVehicleRequest
            {
                LicensePlate = "987654321M",
                ManufacturingDate = DateTime.UtcNow.AddYears(-3),
                Model = "Coupe",
            };

            IWebApiPresenter result = null;

            // Act
            await Fixture.UsingHandlerForRequestResponse<CreateVehicleRequest, IWebApiPresenter>(
                async handler =>
                {
                    result = await handler.Handle(request, default);
                });

            // Assert
            result.Should().NotBeNull();
            result.ActionResult.Should().BeOfType<CreatedAtActionResult>();
        }
    }
}
