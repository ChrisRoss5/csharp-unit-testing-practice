namespace LearningOutcome8.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        private Mock<ITransportableVehicle> _vehicleMock;
        private Mock<ITrain> _trainMock;
        private Mock<IElectricVehicle> _electricVehicleMock;
        private Mock<IGasolineVehicle> _gasolineVehicleMock;
        private Employee _employee;

        [TestInitialize]
        public void TestInitialize()
        {
            _vehicleMock = new Mock<ITransportableVehicle>();
            _trainMock = new Mock<ITrain>();
            _electricVehicleMock = new Mock<IElectricVehicle>();
            _gasolineVehicleMock = new Mock<IGasolineVehicle>();
            _employee = new Employee("Test Employee", 10);
        }

        [TestMethod]
        public void ParkVehicle_ShouldIncreaseTotalEarnings()
        {
            // Arrange
            _vehicleMock.Setup(v => v.TransportFare).Returns(100);

            // Act
            _employee.ParkVehicle(_vehicleMock.Object, _trainMock.Object);

            // Assert
            Assert.AreEqual(10, _employee.TotalEarnings);
        }

        [TestMethod]
        public void ChargeVehicle_ShouldChargeBatteryWhenLow()
        {
            // Arrange
            _electricVehicleMock.Setup(v => v.BatteryPercentage).Returns(5);

            // Act
            _employee.ChargeVehicle(_electricVehicleMock.Object);

            // Assert
            _electricVehicleMock.Verify(v => v.ChargeBattery(), Times.Once);
        }

        [TestMethod]
        public void RefuelVehicle_ShouldRefuelWhenLow()
        {
            // Arrange
            _gasolineVehicleMock.Setup(v => v.FuelPercentage).Returns(5);

            // Act
            _employee.RefuelVehicle(_gasolineVehicleMock.Object);

            // Assert
            _gasolineVehicleMock.Verify(v => v.Refuel(), Times.Once);
        }
        [TestMethod]
        public void ChargeVehicle_ShouldNotChargeBatteryWhenHigh()
        {
            // Arrange
            _electricVehicleMock.Setup(v => v.BatteryPercentage).Returns(95);

            // Act
            _employee.ChargeVehicle(_electricVehicleMock.Object);

            // Assert
            _electricVehicleMock.Verify(v => v.ChargeBattery(), Times.Never);
        }

        [TestMethod]
        public void RefuelVehicle_ShouldNotRefuelWhenHigh()
        {
            // Arrange
            _gasolineVehicleMock.Setup(v => v.FuelPercentage).Returns(95);

            // Act
            _employee.RefuelVehicle(_gasolineVehicleMock.Object);

            // Assert
            _gasolineVehicleMock.Verify(v => v.Refuel(), Times.Never);
        }
    }
}