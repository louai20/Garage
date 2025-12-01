using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class Bus: Vehicle
    {
        public int SeatingCapacity { get; set; }
        public Bus(string regNo, string color, double length, int seatingCapacity)
            : base(regNo, color, length)
        {
            SeatingCapacity = seatingCapacity;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Seating Capacity: {SeatingCapacity}";
        }
    }
}
