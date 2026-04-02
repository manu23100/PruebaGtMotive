using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Interfaces.Vehicle;
using GtMotive.Estimate.Microservice.Domain.ValueObjects.Vehicle;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Unit tests for the create vehicle use case.
    /// </summary>
    public sealed class CreateVehicleUseCaseTests
    {
        private readonly Mock<ICreateVehicleOutputPort> _outputPortMock;
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IVehicleFactory> _vehicleFactoryMock;
        private readonly CreateVehicleUseCase useCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleUseCaseTests"/> class.
        /// </summary>
        public CreateVehicleUseCaseTests()
        {
            _outputPortMock = new Mock<ICreateVehicleOutputPort>();
            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _vehicleFactoryMock = new Mock<IVehicleFactory>();

            useCase = new CreateVehicleUseCase(
                _outputPortMock.Object,
                _vehicleRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _vehicleFactoryMock.Object);
        }

        /// <summary>
        /// Test the create vehicle use case.
        /// </summary>
        /// <returns>A task representing the asynchronous test operation.</returns>
        [Fact]
        public async Task ExecuteWithValidInputShouldCreateVehicleAndCallOutputPort()
        {
            // Arrange
            var vehicleId = new VehicleId(Guid.NewGuid());
            var vehicleMock = new Mock<IVehicle>();

            vehicleMock.Setup(v => v.Id).Returns(vehicleId);
            vehicleMock.Setup(v => v.Status).Returns(VehicleStatus.Available);

            _vehicleFactoryMock
                .Setup(f => f.NewVehicle(
                    It.IsAny<VehicleId>(),
                    It.IsAny<LicensePlate>(),
                    It.IsAny<ManufacturingDate>(),
                    It.IsAny<Model>()))
                .Returns(vehicleMock.Object);

            _unitOfWorkMock
                .Setup(u => u.Save())
                .ReturnsAsync(1);

            var input = new CreateVehicleInput("12345678X", DateTime.UtcNow.AddMonths(-6), "Sedan");

            // Act
            await useCase.Execute(input);

            // Assert
            _vehicleFactoryMock.Verify(
                f => f.NewVehicle(
                    It.IsAny<VehicleId>(),
                    It.IsAny<LicensePlate>(),
                    It.IsAny<ManufacturingDate>(),
                    It.IsAny<Model>()),
                Times.Once);

            _vehicleRepositoryMock.Verify(r => r.Add(vehicleMock.Object), Times.Once);

            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);

            _outputPortMock.Verify(
                o => o.StandardHandle(It.Is<CreateVehicleOutput>(output => output.Status == VehicleStatus.Available)),
                Times.Once);
        }
    }
}
