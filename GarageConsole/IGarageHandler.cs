using GarageConsole.Vehicles;

namespace GarageConsole
{
    internal interface IGarageHandler
    {
        public void PopulateGarage();
        void ParkVehicle(IVehicle vehicle);
        void RemoveVehicle(string registrationNumber);
        IVehicle? FindVehicle(string registrationNumber);
        IEnumerable<IVehicle> ListVehicles();
        Dictionary<string, int> ListVehicleType();
    }
}