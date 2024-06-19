using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageConsole.Helper;
using GarageConsole.Vehicles;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GarageConsole
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {

        private T[] _vehicles;
        private int _count;

        public Garage(int capacity)
        {
            _vehicles = new T[capacity];
            
            _count = 0;
        }

        //park vehicle func
        public bool ParkVehicle(T vehicle)
        {
            if (_count >= _vehicles.Length)
            {
                return false;
            }
            _vehicles[_count++] = vehicle;
            return true;
         }

        //Remove vehicle from park func
        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_vehicles[i].RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Flytta sista fordonet till denna plats
                    _vehicles[i] = _vehicles[--_count];
                    // Sätt den sista platsen till standardvärdet
                    _vehicles[_count] = default(T);
                    return true;
                }
            }
            return false;
        }

        //Search for Vehicle in the garage
        public T? FindVehicle(string registrationNumber)
        {
            foreach (T vehicle in this)
            {
                if (vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return vehicle;
                }
            }
            return default(T);
        }

        // make possible to to iterate over collection and return one by one element with yield return 
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        } 
    }
}
