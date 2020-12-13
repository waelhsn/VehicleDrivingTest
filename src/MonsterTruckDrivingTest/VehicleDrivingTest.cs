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
            //input the vehicle setting, positions & directions variables.
            int x = 0, y = 0, currentX, currentY, width = 0, length = 0;
            char initialDirection, currentDirection;
            string commands;
            bool pass = false;

            //Input and validation of surface width and length.
            do
            {
                Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

                var dimensions = ReadLine();
                if (dimensions.Contains(',') &&
                    int.TryParse(dimensions.Split(',')[0],
                    out width) &&
                    int.TryParse(dimensions.Split(',')[1],
                    out length) &&
                    width > 0 && length > 0)
                    pass = true;
                else
                    WriteLine("ERROR. Invalid dimensions. Please try again.");
            } while (!pass);

            //Input and validation of x, y positions.
            pass = false;
            do
            {
                Write($"Starting position of the monstertruck (in terms of X and Y (e.g: 0,0)): ");

                var position = ReadLine();
                if (position.Contains(',') &&
                    int.TryParse(position.Split(',')[0], out x) &&
                    int.TryParse(position.Split(',')[1], out y) &&
                    x >= 0 && y >= 0 &&
                    x <= width - 1 && y <= length - 1)
                    pass = true;

                else
                    WriteLine("ERROR. Invalid coordinators. Please try again.");
            } while (!pass);

            //Input and validation of direction.
            pass = false;
            do
            {
                Write($"Direction of the monstertruck at the start point (N, E, S or W): ");
                initialDirection = ReadLine().ToUpper()[0];
                if (new[] { 'N', 'E', 'S', 'W' }.Contains(initialDirection))
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

            //Input and validation of driving commands.
            do
            {
                //Setting the allowed commands for this driving session.
                var allowedCommands = new[] { 'F', 'B', 'R', 'L'};
                Write("Commands to be executed for final driving result: ");
                commands = ReadLine().ToUpper();

                foreach (var command in commands)

                    if (!allowedCommands.Contains(command))
                        pass = false;

                if (!pass)
                    WriteLine("ERROR: Commands contain a character that doesn't belong to allowed set. Please try again.");

            } while (!pass);

            //A vector creator for directions.
            var directionsVector = ImmutableList.Create<char>('N', 'E', 'S', 'W');
            currentX = x;
            currentY = y;
            currentDirection = initialDirection;

            //Process the commands.
            foreach (var command in commands)
            {
                //Commands switch of possibilities scenarios.
                switch (command)
                {
                    //Steps cases
                    case 'F':
                        Write("Forwarded ");
                        currentX += currentDirection == 'E' ? 1 : currentDirection == 'W' ? -1 : 0;
                        currentY += currentDirection == 'N' ? 1 : currentDirection == 'S' ? -1 : 0;
                        break;

                    case 'B':
                        Write("Backwarded ");
                        currentX += currentDirection == 'E' ? -1 : currentDirection == 'W' ? 1 : 0;
                        currentY += currentDirection == 'N' ? -1 : currentDirection == 'S' ? 1 : 0;
                        break;

                        //Rotation cases
                    case 'R':
                        Write("Rotating 90° to the right ");
                        currentDirection = directionsVector[(directionsVector.IndexOf(currentDirection) + 1) % 4];
                        break;

                    case 'L':
                        Write("Rotating 90° to the left, ");
                        currentDirection = directionsVector[directionsVector.IndexOf(currentDirection) == 0 ? 3 :
                            (directionsVector.IndexOf(currentDirection) - 1) % 4];
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