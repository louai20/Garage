using Garage.interfaces;
using Garage.UI;

namespace Garage
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Garage Simulator!");

            // Ask the user for garage capacity
            int capacity = PromptForInt("Enter garage capacity: ");

            // Create a garage and handler
            Garage<IVehicle> garage = new Garage<IVehicle>(capacity);
            GarageHandler<IVehicle> handler = new GarageHandler<IVehicle>(garage);

            // Create the Console UI and start the main loop
            ConsoleUI ui = new ConsoleUI(handler);
            ui.HandleUserInput();
        }

        private static int PromptForInt(string message)
        {
            int result;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. " + message);
            }
            return result;
        }
    }
}
