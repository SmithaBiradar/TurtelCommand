using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurtleSim;

namespace TurtleSimulationStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Turtle Command Simulation");

            var driver = new TurtleDriver(new Turtle());

            while (true)
            {
                string command = PromptForCommand();
              
                Console.WriteLine(driver.Command(command));
            }
        }
        private static string PromptForCommand()
        {
            Console.WriteLine("Please Enter your input: ");
            return Console.ReadLine();
        }

    }
}
