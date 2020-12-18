using static System.Console;
using System.Linq;
using System;

namespace MonsterTruckDrivingTest.Model
{
    public class DimensionsPositionsCrator
    {
        public int width = new SurfaceProperties().Width;
        public int length = new SurfaceProperties().Length;
        public string commands = new VehicleProperties().Commands;
        public bool pass = new VehicleProperties().Pass;
        public int X = new Position().X;
        public int Y = new Position().Y;
        public int currentX = new Position().CurrentX;
        public int currentY = new Position().CurrentY;
        public Directions initialDirection;

        public void CreateNewDimensions()
        {
            Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

            var dimensions = ReadLine();
            try
            {
                int.TryParse(dimensions.Split(',')[0], out int widthValue);
                int.TryParse(dimensions.Split(',')[1], out int lengthValue);
                width = widthValue;
                length = lengthValue;
            }
            catch { }

            if (dimensions.Contains(',') &&
                int.TryParse(dimensions.Split(',')[0], out _) &&
                int.TryParse(dimensions.Split(',')[1], out _) &&
                width > 0 && length > 0)
                pass = true;
            else
                WriteLine("ERROR. Invalid dimensions. Please try again.");
        }

        public void CreateNewPosition()
        {
            Write($"Starting position of the monstertruck (in terms of X and Y (e.g: 0,0)): ");
            var position = ReadLine();
            try
            {
                int.TryParse(position.Split(',')[0], out int xValue);
                int.TryParse(position.Split(',')[1], out int yValue);
                X = xValue;
                Y = yValue;
            }
            catch { }

            if (position.Contains(',') &&
                int.TryParse(position.Split(',')[0], out _) &&
                int.TryParse(position.Split(',')[1], out _) &&
                X >= 0 && Y >= 0 &&
                X <= width - 1 && Y <= width - 1)
                pass = true;
            else
                WriteLine("ERROR. Invalid coordinators. Please try again.");
        }

        public void DirectionsValidation()
        {
            do
            {
                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
                bool isValid = Enum.TryParse(ReadLine(), out initialDirection);
                if (isValid)
                    pass = true;
                else
                    WriteLine("ERROR. Invalid direction. Please try again.");
            } while (!pass);

            WriteLine(@"
                      The following commands are supported for execution:
                       * F = Forwards one step.
                       * B = Backwards one step.
                       * R = Rotate 90° to the right.
                       * L = Rotate 90° to the left.
                        ");

            //Setting the allowed commands for this driving session.
            do
            {
                var allowedCommands = new[] { 'F', 'B', 'R', 'L' };
                Write("Commands to be executed for final driving result: ");
                commands = ReadLine().ToUpper();

                foreach (var command in commands)


                    if (!allowedCommands.Contains(command))
                        pass = false;
                if (!pass)
                    WriteLine("ERROR: Commands contain a character that doesn't belong to allowed set. Please try again.");

            } while (!pass);
        }

        public void GearStick()
        {
            currentX = X;
            currentY = Y;
            Directions currentDirection = initialDirection;

            foreach (var command in commands)
            {
                //Commands switch of possibilities scenarios.
                switch (command)
                {
                    //Steps cases
                    case 'F':
                        Write("Forwarded ");
                        currentX += currentDirection == Directions.East ? 1 : currentDirection == Directions.West ? -1 : 0;
                        currentY += currentDirection == Directions.North ? 1 : currentDirection == Directions.South ? -1 : 0;
                        break;

                    case 'B':
                        Write("Backwarded ");
                        currentX += currentDirection == Directions.East ? -1 : currentDirection == Directions.West ? 1 : 0;
                        currentY += currentDirection == Directions.North ? -1 : currentDirection == Directions.South ? 1 : 0;
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
                if (currentX < 0 || currentY < 0 || currentX >= width || currentY >= length)
                {
                    WriteLine($"Uh oh, we hit the wall!({currentX}, {currentY})");
                    break;
                }

                WriteLine($"{currentX}, {currentY} as a postion, \nDirection: {currentDirection}");
            }
        }
    }
}