namespace PI_Projekt_ISHOD_8.Tests
{
    [TestClass]
    public class TerminalTests
    {
        private Mock<ITransportableVehicle> _smallVehicleMock;
        private Mock<ITransportableVehicle> _largeVehicleMock;
        private Mock<IEmployee> _employeeMock;
        private Terminal _terminal;

        [TestInitialize]
        public void TestInitialize()
        {
            _smallVehicleMock = new Mock<ITransportableVehicle>();
            _largeVehicleMock = new Mock<ITransportableVehicle>();
            _employeeMock = new Mock<IEmployee>();
            _terminal = Terminal.TerminalInstance;
        }

        [TestMethod]
        public void ParkVehicles_ShouldParkVehiclesInTrain()
        {
            // Arrange
            _smallVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Small);
            _largeVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Large);
            var vehicles = new List<ITransportableVehicle> { _smallVehicleMock.Object, _largeVehicleMock.Object };

            // Act
            _terminal.ParkVehicles(vehicles, _employeeMock.Object);

            // Assert
            _employeeMock.Verify(e => e.ParkVehicle(_smallVehicleMock.Object, It.IsAny<ITrain>()), Times.Once);
            _employeeMock.Verify(e => e.ParkVehicle(_largeVehicleMock.Object, It.IsAny<ITrain>()), Times.Once);
        }

        [TestMethod]
        public void Reset_ShouldClearTrains()
        {
            // Arrange
            _smallVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Small);
            var vehicles = new List<ITransportableVehicle> { _smallVehicleMock.Object };

            // Act
            _terminal.ParkVehicles(vehicles, _employeeMock.Object);
            _terminal.Reset();

            // Assert
            _employeeMock.Verify(e => e.ParkVehicle(_smallVehicleMock.Object, It.IsAny<ITrain>()), Times.Once);
            _employeeMock.Verify(e => e.ParkVehicle(It.IsAny<ITransportableVehicle>(), It.IsAny<ITrain>()), Times.Once);
        }
    }
}
