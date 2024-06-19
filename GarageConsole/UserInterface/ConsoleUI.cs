using GarageConsole.Garage;
using GarageConsole.Helper;
using GarageConsole.Vehicles;

namespace GarageConsole.UserInterface
{
    internal class ConsoleUI : IConsoleUI
    {
        private readonly IGarageHandler _garageHandler;

        public ConsoleUI(IGarageHandler garageHandler)
        {
            _garageHandler = garageHandler;
        }


        public void ShowMeny()
        {
            bool running = true;

            while (running)
            {

                HelperMethods.ShowMessage("Garage Menu:");
                HelperMethods.ShowMessage("1. Park Vehicle");
                HelperMethods.ShowMessage("2. Remove Vehicle");
                HelperMethods.ShowMessage("3. List Vehicles");
                HelperMethods.ShowMessage("4. List vehicles type and amount in garage");
                HelperMethods.ShowMessage("5. Find Vehicle");
                HelperMethods.ShowMessage("6. Exit");
                HelperMethods.ShowMessage("Select an option: ");
                string input = HelperMethods.GetInput();

                switch (input)
                {
                    case "1":
                        ParkVehicle();
                        break;
                    case "2":
                        RemoveVehicle();
                        break;
                    case "3":
                        ListVehicle();
                        break;
                    case "4":
                        ListVehicleType();
                        break;
                    case "5":
                        FindVehicle();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        HelperMethods.ShowMessage("Invalid option");
                        break;
                }
            }
        }

      

        private void ParkVehicle()
        {
            HelperMethods.ShowMessage("Enter vehicle type (1: Car, 2: Motorcycle, 3: Airplane, 4: Bus, 5: Boat): ");
            string type = HelperMethods.GetInput();

            HelperMethods.ShowMessage("Enter registration number:");
            string registrationNumber = HelperMethods.GetInput();

            HelperMethods.ShowMessage("Enter color:");
            string color = HelperMethods.GetInput();


            int numberOfWheels = HelperMethods.ReadInt("Enter number of wheels:");

            IVehicle vehicle;

            switch (type)
            {
                case "1":
                    Console.Write("Enter fuel type: ");
                    string fuelType = HelperMethods.GetInput();
                    vehicle = new Car(registrationNumber, color, numberOfWheels, fuelType);
                    break;
                case "2":
                    int cylinderVolume = HelperMethods.ReadInt("Enter cylinder volume: ");
                    vehicle = new Motorcycle(registrationNumber, color, numberOfWheels, cylinderVolume);
                    break;
                case "3":
                    int numberOfEngines = HelperMethods.ReadInt("Enter number of engines: ");
                    vehicle = new Airplane(registrationNumber, color, numberOfWheels, numberOfEngines);
                    break;
                case "4":
                    int numberOfSeats = HelperMethods.ReadInt("Enter number of seats: ");
                    vehicle = new Bus(registrationNumber, color, numberOfWheels, numberOfSeats);
                    break;
                case "5":
                    double length = HelperMethods.ReadDouble("Enter length: ");
                    vehicle = new Boat(registrationNumber, color, numberOfWheels, length);
                    break;
                default:
                    HelperMethods.ShowMessage("Invalid vehicle type.");
                    return;
            }

            //add all the vehicles 
            if (vehicle != null)
            {
                _garageHandler.ParkVehicle(vehicle);
            }
        }


        private void RemoveVehicle()
        {
            HelperMethods.ShowMessage("--------------------------------------Removed from park---------------------------------------------");
            HelperMethods.ShowMessage("Enter registration number: ");
            string registrationNumber = HelperMethods.GetInput();
            _garageHandler.RemoveVehicle(registrationNumber);
            HelperMethods.ShowMessage("------------------------------------------------------------------------------------");

        }


        private void ListVehicle()
        {
            var vehicles = _garageHandler.ListVehicles();
            HelperMethods.ShowMessage("--------------------------------------List of Vehicles---------------------------------------------");
            foreach (var vehicle in vehicles)
            {

                HelperMethods.ShowMessage(vehicle.ToString());
            }
            HelperMethods.ShowMessage("---------------------------------------------------------------------------------------------------");
        }


        private void ListVehicleType()
        {
            var vehicleTypesCount = _garageHandler.ListVehicleType();
            HelperMethods.ShowMessage("------------------------Type of vehicle and amount of each vehicle typ------------------------------");
            foreach (var item in vehicleTypesCount)
            {
                HelperMethods.ShowMessage($"value type: {item.Key}: count: {item.Value}");
            }
            HelperMethods.ShowMessage("------------------------------------------------------------------------------------");



        }

        private void FindVehicle()
        {
            HelperMethods.ShowMessage("Enter registration number: ");
            string registrationNumber = HelperMethods.GetInput();

            var vehicle = _garageHandler.FindVehicle(registrationNumber);

            if (vehicle != null)
            {
                HelperMethods.ShowMessage("------------------------------------------------------------------------------------");
                HelperMethods.ShowMessage(vehicle.ToString());
                HelperMethods.ShowMessage("------------------------------------------------------------------------------------");
            }
            else
            {
                HelperMethods.ShowMessage("------------------------------------------------------------------------------------");
                HelperMethods.ShowMessage("Vehicle not found");
                HelperMethods.ShowMessage("------------------------------------------------------------------------------------");
            }
        }


    }
}