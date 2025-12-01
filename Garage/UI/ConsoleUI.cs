using Garage.interfaces;
using Garage.vehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.UI
{
    public class ConsoleUI : IUI
    {
        private GarageHandler<IVehicle> garageHandler;

        public ConsoleUI(GarageHandler<IVehicle> handler) => garageHandler = handler; 

        public void ShowMenu()
        {
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Remove Vehicle");
            Console.WriteLine("3. List Vehicles");
            Console.WriteLine("4. Find Vehicle");
            Console.WriteLine("5. List Vehicle Types Count");
            Console.WriteLine("6. Search Vehicles by Property");
            Console.WriteLine("7. Exit");
        }

        public void HandleUserInput()
        {
            while (true)
            {
                ShowMenu();
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddVechicleMenu();
                        break;
                    case "2":
                        RemoveVehicleMenu();
                        break;
                    case "3":
                        garageHandler.ListAllVehicles();
                        break;
                    case "4":
                        FindVehicleMenu();
                        break;
                    case "5":
                        garageHandler.ListVehicleTypes();
                        break;
                    case "6":
                        SearchVehicleMenu();
                        break;
                    case "7":
                        return; // Exit
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        private void AddVechicleMenu()
        {
            Console.Write("Choose vehicle type (1. Car, 2. Bus, 3. Boat, 4. Motorcycle, 5. AirPlane): ");
            var typeChoice = Console.ReadLine();
            Console.Write("Enter Registration Number: ");
            string regNo = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Color: ");
            string color = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Length: ");
            if (!double.TryParse(Console.ReadLine(), out double length)) // Parsing length as double
            {
                Console.WriteLine("Invalid length. Operation cancelled.");
                return;
            }
            IVehicle vehicle = typeChoice switch
            {
                "1" => new Car(regNo, color, length, PromptForString("Enter Fuel Type: ")),
                "2" => new Bus(regNo, color, length, PromptForInt("Enter Number of Seats: ")),
                "3" => new Boat(regNo, color, length, PromptForDouble("Enter Width: ")),
                "4" => new Motorcycle(regNo, color, length, PromptForString("Enter Engine Capacity (cc): ")),
                "5" => new AirPlane(regNo, color, length, PromptForDouble("Enter wingspan: ")),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
            garageHandler.AddVehicle(vehicle);

        }
        private void RemoveVehicleMenu()
        {
            string regNo = PromptForString("Enter Registration Number of vehicle to remove: ");
            garageHandler.RemoveVehicle(regNo);
        }

        private string PromptForString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        private void FindVehicleMenu()
        {
            Console.Write("Enter Registration Number of vehicle to find: ");
            string regNo = Console.ReadLine() ?? string.Empty;

            var vehicle = garageHandler.GetVehicle(regNo);
            if (vehicle != null)
                Console.WriteLine(vehicle);
            else
                Console.WriteLine("Vehicle not found.");
        }

        private void SearchVehicleMenu()
        {
            string color = PromptForString("Color (empty = ignore): ");
            double length = PromptForDouble("Length (-1 = ignore): ");

            var results = garageHandler.SearchVehicles(v =>
                (string.IsNullOrWhiteSpace(color) ||
                 v.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                &&
                (length < 0 || v.Length == length)
            );

            bool foundAny = false;
            foreach (var vehicle in results)
            {
                Console.WriteLine(vehicle);
                foundAny = true;
            }

            // Only print "No vehicles found" if nothing matched
            if (!foundAny)
            {
                Console.WriteLine("No vehicles found matching criteria.");
            }
        }

        private int PromptForInt(string message)
        {
            int result;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. " + message);
            }
            return result;
        }

        private double PromptForDouble(string message)
        {
            double result;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. " + message);
            }
            return result;
        }
    }
}
