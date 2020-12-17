using MonsterTruckDrivingTest.Model;
using static System.Console;
using System.Linq;
using System;

namespace MonsterTruckDrivingTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("* * * Welcome to Monster Truck driving test * * *");

                var vehicle = new VehicleProperties();
                var surface = new SurfaceProperties();
                var vehiclePosition = new Position();

                //Input and validation of surface width and length.
                do
                {
                    Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

                    var dimensions = ReadLine();
                    try
                    {

                        int.TryParse(dimensions.Split(',')[0], out int widthValue);
                        int.TryParse(dimensions.Split(',')[1], out int lengthValue);
                        surface.Width = widthValue;
                        surface.Length = lengthValue;

                    }
                    catch { }


                    if (dimensions.Contains(',') &&
                        int.TryParse(dimensions.Split(',')[0], out _) &&

                        int.TryParse(dimensions.Split(',')[1], out _) &&

                        surface.Width > 0 && surface.Length > 0)
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
                    try
                    {

                        int.TryParse(position.Split(',')[0], out int xValue);
                        int.TryParse(position.Split(',')[1], out int yValue);
                        vehiclePosition.X = xValue;
                        vehiclePosition.Y = yValue;
                    }
                    catch { }

                    if (position.Contains(',') &&
                        int.TryParse(position.Split(',')[0], out _) &&
                        int.TryParse(position.Split(',')[1], out _) &&
                        vehiclePosition.X >= 0 && vehiclePosition.Y >= 0 &&
                        vehiclePosition.X <= surface.Width - 1 && vehiclePosition.Y <= surface.Length - 1)
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

                vehiclePosition.CurrentX = vehiclePosition.X;
                vehiclePosition.CurrentY = vehiclePosition.Y;

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
                            vehiclePosition.CurrentX += currentDirection == Directions.East ? 1 : currentDirection == Directions.West ? -1 : 0;
                            vehiclePosition.CurrentY += currentDirection == Directions.North ? 1 : currentDirection == Directions.South ? -1 : 0;
                            break;

                        case 'B':
                            Write("Backwarded ");
                            vehiclePosition.CurrentX += currentDirection == Directions.East ? -1 : currentDirection == Directions.West ? 1 : 0;
                            vehiclePosition.CurrentY += currentDirection == Directions.North ? -1 : currentDirection == Directions.South ? 1 : 0;
                            break;

                        //Rotation cases
                        case 'R':
                            Write("Rotating 90° to the right ");
                            currentDirection = (currentDirection + 1);

                            break;

                        case 'L':
                            Write("Rotating 90° to the left, ");
                            currentDirection = currentDirection == 0 ? Directions.West : currentDirection - 1;
                            break;
                    }

                    //checker, if we hit a wall.
                    if (vehiclePosition.CurrentX < 0 || vehiclePosition.CurrentY < 0 || vehiclePosition.CurrentX >= surface.Width || vehiclePosition.CurrentY >= surface.Length)
                    {
                        WriteLine($"Uh oh, we hit the wall!({vehiclePosition.CurrentX}, {vehiclePosition.CurrentY})");
                        break;
                    }

                    WriteLine($"{vehiclePosition.CurrentX}, {vehiclePosition.CurrentY} as a postion, \nDirection: {currentDirection}");
                }

            }
        }
    }
}