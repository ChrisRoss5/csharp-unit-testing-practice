namespace LearningOutcome8.Tests
{
    [TestClass]
    public class TrainTests
    {
        private Mock<ITransportableVehicle> _smallVehicleMock;
        private Mock<ITransportableVehicle> _largeVehicleMock;
        private SmallTrain _smallTrain;
        private LargeTrain _largeTrain;

        [TestInitialize]
        public void TestInitialize()
        {
            _smallVehicleMock = new Mock<ITransportableVehicle>();
            _largeVehicleMock = new Mock<ITransportableVehicle>();
            _smallTrain = new SmallTrain();
            _largeTrain = new LargeTrain();
        }

        [TestMethod]
        public void AddVehicleToSmallTrain_ShouldAddVehicleWhenNotFull()
        {
            // Arrange
            _smallVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Small);

            // Act
            _smallTrain.AddVehicle(_smallVehicleMock.Object);

            // Assert
            Assert.AreEqual(1, _smallTrain.BoardedVehicles.Count);
        }

        [TestMethod]
        public void AddVehicleToLargeTrain_ShouldAddVehicleWhenNotFull()
        {
            // Arrange
            _largeVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Large);

            // Act
            _largeTrain.AddVehicle(_largeVehicleMock.Object);

            // Assert
            Assert.AreEqual(1, _largeTrain.BoardedVehicles.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Train is full")]
        public void AddVehicleToSmallTrain_ShouldThrowExceptionWhenFull()
        {
            // Arrange
            _smallVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Small);
            for (int i = 0; i < _smallTrain.MaxCapacity; i++)
                _smallTrain.AddVehicle(_smallVehicleMock.Object);

            // Act
            _smallTrain.AddVehicle(_smallVehicleMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Train is full")]
        public void AddVehicleToLargeTrain_ShouldThrowExceptionWhenFull()
        {
            // Arrange
            _largeVehicleMock.Setup(v => v.VehicleSize).Returns(VehicleSize.Large);
            for (int i = 0; i < _largeTrain.MaxCapacity; i++)
                _largeTrain.AddVehicle(_largeVehicleMock.Object);

            // Act
            _largeTrain.AddVehicle(_largeVehicleMock.Object);
        }
    }
}
