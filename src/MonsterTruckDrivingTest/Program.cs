using static MonsterTruckDrivingTest.Helper.EnvironmentHelper;
using MonsterTruckDrivingTest.Helper;
using MonsterTruckDrivingTest.Model;
using System.Collections.Generic;

namespace MonsterTruckDrivingTest
{
    public class Program
    {
        public static void Main()
        {
            WriteLine("* * * Welcome to Monster Truck driving test * * *");

            var surface = new Surface();
            Vehicle monsterTruck = new Vehicle();

            //Input validation for vehicle postion vs surface
            do
            {
                Pass = monsterTruck.IsInsideSurface(surface);
                
                if (!Pass)
                {
                    ErrorMessage = "ERROR: Defined vehicle is outside defined surface. Try again.";
                    surface = new Surface();
                    monsterTruck = new Vehicle();
                }
                else break;
            } while (true);

            //Command validation
            List<Command> commands = new List<Command>();

            do
            {
                commands = new List<Command>();
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
                    if (System.Enum.GetName(typeof(Command), command) != null)
                        commands.Add((Command)command);
                    else
                        WriteLine($"WARNING: Ignoring unknown command: {command}");

                if (commands.Count == 0)
                    ErrorMessage = "ERROR: No command to execute.";
                else if (!monsterTruck.Move(surface, ref commands))
                {
                    ErrorMessage = "\n\nERROR: We hit the wall. \n\nDriving session has ended.";
                    break;
                }
            } while (true);
        }
    }
}