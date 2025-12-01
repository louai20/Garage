using Garage.interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage 
{ 
public class Garage<T> : IEnumerable<T> where T : class, IVehicle
{
    private T?[] vehicles; 
    private int count = 0;

    public Garage(int capacity)
    {
        vehicles = new T?[capacity];
    }

    public void AddVehicle(T vehicle)
    {
        if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
        if (count >= vehicles.Length) throw new InvalidOperationException("Garage is full.");

        // Check unique registration number
        if (Array.Exists(vehicles, v => v != null &&
            v.RegistrationNumber.Equals(vehicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Vehicle with this registration number already exists.");
        }

        vehicles[count++] = vehicle;
    }

    public bool RemoveVehicle(string registrationNumber)
    {
        for (int i = 0; i < count; i++)
        {
            if (vehicles[i] != null && vehicles[i]!.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
            {
                vehicles[i] = vehicles[count - 1];
                vehicles[count - 1] = null; // Now valid because array is nullable
                count--;
                return true;
            }
        }
        return false;
    }

    public T? FindVehicle(string registrationNumber)
    {
        return Array.Find(vehicles, v => v != null &&
            v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<T> SearchVehicles(Func<T, bool> predicate)
    {
        for (int i = 0; i < count; i++)
        {
            if (vehicles[i] != null && predicate(vehicles[i]!))
                yield return vehicles[i]!;
        }
    }

    public Dictionary<string, int> GroupByType()
    {
        var result = new Dictionary<string, int>();
        foreach (var v in this)
        {
            string type = v.GetType().Name;
            if (!result.ContainsKey(type))
                result[type] = 0;
            result[type]++;
        }
        return result;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            if (vehicles[i] != null)
                yield return vehicles[i]!;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
}