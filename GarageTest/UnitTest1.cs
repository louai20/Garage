using Xunit;
using Garage;
using Garage.vehicleTypes;

namespace Garage.Tests
{
    public class GarageTests
    {
        private Garage<IVehicle> garage;

        // Constructor runs before each test
        public GarageTests()
        {
            garage = new Garage<IVehicle>(5);
        }

        [Fact]
        public void AddVehicle_ValidVehicle_VehicleAdded()
        {
            IVehicle car = new Car("ABC123", "Red", 4.5, "Gasoline");

            garage.AddVehicle(car);

            var found = garage.FindVehicle("ABC123");
            Assert.NotNull(found);
            Assert.Equal("ABC123", found.RegistrationNumber);
        }

        [Fact]
        public void GetVehicle_NonExistentRegistration_ReturnsNull()
        {
            var result = garage.FindVehicle("NOTFOUND");
            Assert.Null(result);
        }

        [Fact]
        public void RemoveVehicle_ExistingVehicle_ReturnsTrue()
        {
            IVehicle car = new Car("XYZ789", "Blue", 4.2, "Diesel");
            garage.AddVehicle(car);

            bool removed = garage.RemoveVehicle("XYZ789");

            Assert.True(removed);
            Assert.Null(garage.FindVehicle("XYZ789"));
        }

        [Fact]
        public void RemoveVehicle_NonExistingVehicle_ReturnsFalse()
        {
            bool removed = garage.RemoveVehicle("NONEXIST");
            Assert.False(removed);
        }

        [Fact]
        public void AddVehicle_ExceedCapacity_ThrowsException()
        {
            for (int i = 0; i < 5; i++)
                garage.AddVehicle(new Car($"CAR{i}", "Black", 4, "Gasoline"));

            IVehicle extraCar = new Car("EXTRA", "White", 4.5, "Gasoline");

            Assert.Throws<InvalidOperationException>(() => garage.AddVehicle(extraCar));
        }
    }
}
