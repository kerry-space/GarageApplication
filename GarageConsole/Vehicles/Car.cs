using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageConsole.Vehicles;

namespace GarageConsole.Garage
{
    public class Car : Vehicle
    {

        public string FuelType { set; get; }


        public Car(string registrationNumber, string color, int numberOfWheels, string fuelType) :
            base(registrationNumber, color, numberOfWheels)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return base.ToString() + $"Fuel Type. {FuelType}";
        }

    }
}
