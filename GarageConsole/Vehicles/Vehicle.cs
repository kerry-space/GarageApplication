using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsole.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

        protected Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;

        }

        public override string ToString()
        {
            return $"{GetType().Name} - Reg: {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}";

        }
    }
}
