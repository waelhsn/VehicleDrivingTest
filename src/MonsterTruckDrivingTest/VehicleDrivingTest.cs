using MonsterTruckDrivingTest.Model;
using System.Collections.Immutable;
using static System.Console;
using System.Linq;
using System;

namespace MonsterTruckDrivingTest
{
    public class VehicleDrivingTest
    {
        public static void SurfacAndDrivingBuilder()
        {
            VehicleProperties vehicle;
            //Input and validation of surface width and length.
            do
            {
                Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

                var dimensions = ReadLine();
                if (dimensions.Contains(',') &&
                    int.TryParse(dimensions.Split(',')[0],
                    out vehicle.Width) &&
                    int.TryParse(dimensions.Split(',')[1],
                    out vehicle.Length) &&
                    vehicle.Width > 0 && vehicle.Length > 0)
                    vehicle.Pass = true;
                else
                    WriteLine("ERROR. Invalid dimensions. Please try again.");
            } while (!vehicle.Pass);

            //Input and validation of x, y positions.
            vehicle.Pass = false;
            do
            {
                Write($"Starting position of the monstertruck (in terms of X and Y (e.g: 0,0)): ");

                var position = ReadLine();
                if (position.Contains(',') &&
                    int.TryParse(position.Split(',')[0], out vehicle.X) &&
                    int.TryParse(position.Split(',')[1], out vehicle.Y) &&
                    vehicle.X >= 0 && vehicle.Y >= 0 &&
                    vehicle.X <= vehicle.Width - 1 && vehicle.Y <= vehicle.Length - 1)
                    vehicle.Pass = true;

                else
                    WriteLine("ERROR. Invalid coordinators. Please try again.");
            } while (!vehicle.Pass);

            //Input and validation of direction.
            vehicle.Pass = false;
            Directions initialDirection;
            do
            {
                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
                bool isValid = Enum.TryParse(ReadLine(), out initialDirection);
                if (isValid)
                    vehicle.Pass = true;
                else
                    WriteLine("ERROR. Invalid direction. Please try again.");
            } while (!vehicle.Pass);

            WriteLine(@"
                      The following commands are supported for execution:
                       * F = Forwards one step.
                       * B = Backwards one step.
                       * R = Rotate 90° to the right.
                       * L = Rotate 90° to the left.
                        ");

            //CommandsCreator.CommandsBuilder();
           // Input and validation of driving commands.
            do
            {
                //Setting the allowed commands for this driving session.
                var allowedCommands = new[] { 'F', 'B', 'R', 'L' };
                Write("Commands to be executed for final driving result: ");
                vehicle.Commands = ReadLine().ToUpper();

                foreach (var command in vehicle.Commands)

                    if (!allowedCommands.Contains(command))
                        vehicle.Pass = false;

                if (!vehicle.Pass)
                    WriteLine("ERROR: Commands contain a character that doesn't belong to allowed set. Please try again.");

            } while (!vehicle.Pass);

            vehicle.CurrentX = vehicle.X;
            vehicle.CurrentY = vehicle.Y;

            Directions currentDirection = initialDirection;

            //Process the commands.
            foreach (var command in vehicle.Commands)
            {
                //Commands switch of possibilities scenarios.
                switch (command)
                {
                    //Steps cases
                    case 'F':
                        Write("Forwarded ");
                        vehicle.CurrentX += currentDirection == Directions.East ? 1 : currentDirection == Directions.West ? -1 : 0;
                        vehicle.CurrentY += currentDirection == Directions.North ? 1 : currentDirection == Directions.South ? -1 : 0;
                        break;

                    case 'B':
                        Write("Backwarded ");
                        vehicle.CurrentX += currentDirection == Directions.East ? -1 : currentDirection == Directions.West ? 1 : 0;
                        vehicle.CurrentY += currentDirection == Directions.North ? -1 : currentDirection == Directions.South ? 1 : 0;
                        break;

                        //Rotation cases
                    case 'R':
                        Write("Rotating 90° to the right ");
                        currentDirection += 1;
                        break;

                    case 'L':
                        Write("Rotating 90° to the left, ");
                        currentDirection = currentDirection == 0 ?
                            Directions.West : currentDirection - 1;
                        break;
                }

                //checker, if we hit a wall.
                if (vehicle.CurrentX < 0 || vehicle.CurrentY < 0 || vehicle.CurrentX >= vehicle.Width || vehicle.CurrentY >= vehicle.Length)
                {
                    WriteLine($"Uh oh, we hit the wall!({vehicle.CurrentX}, {vehicle.CurrentY})");
                    break;
                }

                WriteLine($"{vehicle.CurrentX}, {vehicle.CurrentY} as a postion, \nDirection: {currentDirection}");
            }

        }

    }
}