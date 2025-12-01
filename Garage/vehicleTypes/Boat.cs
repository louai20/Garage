using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class Boat: Vehicle
    {
        public double Width { get; set; }
        public Boat(string regNo, string color, double length, double lengthInFeet)
            : base(regNo, color, length)
        {
            Width = lengthInFeet;
        }
        public override string ToString()
        {
            return base.ToString() + $", Width: {Width}m";
        }
    }
}
