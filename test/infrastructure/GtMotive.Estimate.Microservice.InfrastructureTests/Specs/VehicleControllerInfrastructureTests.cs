using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfraTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class VehicleControllerInfrastructureTests(GenericInfrastructureTestServerFixture fixture)
        : InfrastructureTestBase(fixture)
    {
        [Fact]
        public async Task CreateVehicleWithEmptyBodyShouldReturnBadRequest()
        {
            // Arrange
            var client = Fixture.Server.CreateClient();

            using var content = new StringContent("{}", Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(new Uri("/vehicle", UriKind.Relative), content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
