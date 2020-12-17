using MonsterTruckDrivingTest.Model;
using System;
using System.Linq;
using static System.Console;

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
                var vehiclePosition = new Position();
                var dimensionsPositionsCrator = new DimensionsPositionsCrator();

                //Input and validation of surface width and length.
                do
                {
                    dimensionsPositionsCrator.CreateNewDimensions();
                    break;
                } while (!vehicle.Pass);

                //Input and validation of x, y positions.
                vehicle.Pass = false;
                do
                {
                    dimensionsPositionsCrator.CreateNewPosition();
                    break;
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

                vehiclePosition.CurrentX = dimensionsPositionsCrator.X;
                vehiclePosition.CurrentY = dimensionsPositionsCrator.Y;

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
                    if (vehiclePosition.CurrentX < 0 || vehiclePosition.CurrentY < 0 || vehiclePosition.CurrentX >= dimensionsPositionsCrator.width || vehiclePosition.CurrentY >= dimensionsPositionsCrator.length)
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