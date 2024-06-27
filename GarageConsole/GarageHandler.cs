
using GarageConsole.Garage;
using GarageConsole.Helper;
using GarageConsole.Vehicles;

namespace GarageConsole
{
    internal class GarageHandler : IGarageHandler
    {
        private Garage<IVehicle> _garage;

        public  GarageHandler(int capacity) 
        {
            _garage = new Garage<IVehicle>(capacity);
        }


        public void PopulateGarage()
        {
            ParkVehicle(new Car("ABC123", "Red", 4, "Gasoline"));
            ParkVehicle(new Motorcycle("XYZ789", "Blue", 2, 600));
            ParkVehicle(new Airplane("PLN456", "White", 3, 2));
            ParkVehicle(new Bus("BUS001", "Yellow", 6, 50));
            ParkVehicle(new Boat("BOAT01", "Black", 0, 20.5));
        }



        public void ParkVehicle(IVehicle vehicle)
        {
            if (_garage.ParkVehicle(vehicle))
            {
               HelperMethods.ShowMessage($"{vehicle.GetType().Name} parked.");
            }
            else
            {
                HelperMethods.ShowMessage("Garage is full.");
            }
        }


        public void RemoveVehicle(string registrationNumber)
        {
            if (_garage.RemoveVehicle(registrationNumber))
            {
                HelperMethods.ShowMessage($"Vehicle wíth registration number {registrationNumber} removed.");
            }
            else
            {
                HelperMethods.ShowMessage($"Vehicle wíth registration number {registrationNumber} not found.");
            }
        }


        public IVehicle? FindVehicle(string registrationNumber)
        {
            return _garage.FirstOrDefault(v => v.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            //if (vehicle != null)
            //{
            //    return vehicle;
            //}
            //return default;
        }

        public Dictionary<string, int> ListVehicleType()
        {
          return _garage
                .GroupBy(v => v.GetType().Name)
                .ToDictionary(g => g.Key, g => g.Count());
        }


        public IEnumerable<IVehicle> ListVehicles()
        {
            return _garage;  
        }
     
    }
}