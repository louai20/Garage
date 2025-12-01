using Garage.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Color { get; set; }
        public double Length { get; set; }

        public Vehicle(string regNo, string color, double length)
        {
            RegistrationNumber = regNo;
            Color = color;
            Length = length;
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {RegistrationNumber}, Color: {Color}, Numbers of wheels: {Length}";
        }
    }
}
