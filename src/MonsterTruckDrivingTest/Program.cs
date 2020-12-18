using MonsterTruckDrivingTest.Helper;
using static MonsterTruckDrivingTest.Helper.Shared;
using MonsterTruckDrivingTest.Model;
using System.Collections.Generic;

namespace MonsterTruckDrivingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("* * * Welcome to Monster Truck driving test * * *");

            var surface = new Surface();
            var vehicle = new Vehicle();

            //Input validation for vehicle postion vs surface
            do
            {
                Pass = vehicle.IsInsideSurface(surface);
                if (!Pass)
                {
                    ErrorMessage = "ERROR: Defined vehicle is outside defined surface. Try again.";
                    surface = new Surface();
                    vehicle = new Vehicle();
                }
                else break;
            } while (true);


            //Command validation
            List<CommandEnum> commands;

            do
            {
                commands = new List<CommandEnum>();
                Write(@"
                The following commands are supported for execution (Type EXIT to exit):
                * F = Forwards one step.
                * B = Backwards one step.
                * R = Rotate 90° to the right.
                * L = Rotate 90° to the left.

                Commands to be executed for final driving result: ");

                var input = ReadLine().ToUpper();
                if (input == "EXIT")
                    break;

                foreach (char command in input)
                    if (System.Enum.GetName(typeof(CommandEnum), command) != null)
                        commands.Add((CommandEnum)command);
                    else
                        WriteLine($"WARNING: Ignoring unknown command: {command}");

                if (commands.Count == 0)
                    ErrorMessage = "ERROR: No command to execute.";
                else if (!vehicle.Move(surface, ref commands))
                    ErrorMessage = "ERROR: We hit the wall.";
            } while (true);
        }
    }
}