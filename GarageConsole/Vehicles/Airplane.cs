using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageConsole.Vehicles;

namespace GarageConsole.Garage
{
    internal class Airplane : Vehicle
    {

        public int NumberOfEngines { set; get; }

        public Airplane(string registrationNumber, string color, int numberOfWheels, int numberOfEngines) :
            base(registrationNumber, color, numberOfWheels)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() + $"Engines: {NumberOfEngines}";
        }

    }
}
