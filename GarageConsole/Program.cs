using System.ComponentModel;
using GarageConsole.UserInterface;

namespace GarageConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IGarageHandler garageHandler = new GarageHandler(5);
            garageHandler.PopulateGarage();
            IConsoleUI ui = new ConsoleUI(garageHandler);
            ui.ShowMeny();

        }
    }
}
