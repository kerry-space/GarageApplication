
using GarageConsole;
using GarageConsole.Garage;
using GarageConsole.Vehicles;


namespace GarageConsoleTest
{
    public class GarageTests
    {
        [Fact]
        public void ParkVehicle_ShouldAddVehicle_WhenThereIsSpace()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            var car = new Car("ABC123", "Red", 4, "Gasoline");

            // Act
            var result = garage.ParkVehicle(car);

            // Assert
            Assert.True(result);
            Assert.Equal(car, garage.FindVehicle("ABC123"));
        }

        [Fact]
        public void ParkVehicle_ShouldNotAddVehicle_WhenThereIsNoSpace()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);
            var car1 = new Car("ABC123", "Red", 4, "Gasoline");
            var car2 = new Car("XYZ789", "Blue", 4, "Gasoline");
            garage.ParkVehicle(car1);

            // Act
            var result = garage.ParkVehicle(car2);

            // Assert
            Assert.False(result);
            Assert.Null(garage.FindVehicle("XYZ789"));
        }

        [Fact]
        public void RemoveVehicle_ShouldRemoveVehicle_WhenVehicleExists()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);
            var car = new Car("ABC123", "Red", 4, "Gasoline");
            garage.ParkVehicle(car);

            // Act
            var result = garage.RemoveVehicle("ABC123");

            // Assert
            Assert.True(result);
            Assert.Null(garage.FindVehicle("ABC123"));
        }

        [Fact]
        public void RemoveVehicle_ShouldNotRemoveVehicle_WhenVehicleDoesNotExist()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);

            // Act
            var result = garage.RemoveVehicle("ABC123");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FindVehicle_ShouldReturnVehicle_WhenVehicleExists()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);
            var car = new Car("ABC123", "Red", 4, "Gasoline");
            garage.ParkVehicle(car);

            // Act
            var result = garage.FindVehicle("ABC123");

            // Assert
            Assert.Equal(car, result);
        }

        [Fact]
        public void FindVehicle_ShouldReturnNull_WhenVehicleDoesNotExist()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);

            // Act
            var result = garage.FindVehicle("ABC123");

            // Assert
            Assert.Null(result);
        }
    }
}
