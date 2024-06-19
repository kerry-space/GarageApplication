using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageConsole.Helper
{
    public static class HelperMethods
    {
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(GetInput(), out value))
                {
                    break;
                }
                else
                {
                    ShowMessage("Invalid input. Please enter a valid number.");
                }
            }
            return value;
        }

        public static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(GetInput(), out value))
                {
                    break;
                }
                else
                {
                    ShowMessage("Invalid input. Please enter a valid number.");
                }
            }
            return value;
        }
    }

}
