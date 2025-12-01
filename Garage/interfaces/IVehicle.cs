using System;
using System.Collections.Generic;
using System.Text;

namespace Garage
{
    public interface IVehicle
    {
        string RegistrationNumber { get;}
        string Color { get; set; }
        double Length { get; set; }
    }
}
