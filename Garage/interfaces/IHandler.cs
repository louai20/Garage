using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.interfaces
{
    public interface IHandler<T> where T : class,IVehicle
    {
        void AddVehicle(T vehicle);
        bool RemoveVehicle(string registeredOwner);
        T GetVehicle(string registeredOwner);
        IEnumerable<T> SearchVehicles(Func<T,bool> pred);
        void ListAllVehicles();
    }
}
