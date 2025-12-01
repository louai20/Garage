using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(string regNo, string color, double length, string fuelType)
            : base(regNo, color, length)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Fuel Type: {FuelType}";
        }
    }
}
