using Garage.interfaces;

namespace Garage
{
    public class GarageHandler<T> : IHandler<T> where T : class, IVehicle
    {
        public readonly Garage<T> garage;

        public GarageHandler(Garage<T> garage)
        {
            this.garage = garage;
        }

        public void AddVehicle(T vehicle)
        {
            try
            {
                garage.AddVehicle(vehicle);
                Console.WriteLine("Vehicle added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding vehicle: {ex.Message}");
            }
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            bool success = garage.RemoveVehicle(registrationNumber);
            Console.WriteLine(success ? "Vehicle removed." : "Vehicle not found.");
            return success;
        }

        // This is what UI calls
        public T GetVehicle(string registrationNumber)
        {
            return garage.FindVehicle(registrationNumber)!; // Wraps Garage’s FindVehicle, null-forced
        }
        public void ListVehicleTypes()
        {
            var groups = garage.GroupByType();
            foreach (var kv in groups)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }

        public IEnumerable<T> SearchVehicles(Func<T, bool> predicate)
        {
            return garage.SearchVehicles(predicate);
        }

        public void ListAllVehicles()
        {
            foreach (var vehicle in garage) // Use IEnumerable
                Console.WriteLine(vehicle);
        }
    }
}
