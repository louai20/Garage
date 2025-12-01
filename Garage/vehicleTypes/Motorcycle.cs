using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class Motorcycle : Vehicle
    {
        public string FuelType { get; set; } = "Gasoline"; // Default fuel type for motorcycles

        public Motorcycle(string regNo, string color, double length, string fuelType): base(regNo, color, length)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {RegistrationNumber}, Color: {Color}, Length: {Length}";
        }
    }
}
