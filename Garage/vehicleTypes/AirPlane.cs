using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.vehicleTypes
{
    public class AirPlane: Vehicle
    {
        public double WingSpan { get; set; }
        public AirPlane(string regNo, string color, double length, double wingSpan) : base(regNo, color, length)
        {
            WingSpan = wingSpan;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {RegistrationNumber}, Color: {Color}, Length: {Length}, WingSpan: {WingSpan}";
        }
    }
}
