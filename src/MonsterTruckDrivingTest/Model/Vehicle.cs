using static MonsterTruckDrivingTest.Helper.EnvironmentHelper;
using MonsterTruckDrivingTest.Helper;
using System.Collections.Generic;
using System;

namespace MonsterTruckDrivingTest.Model
{
    /// <summary>
    /// Test comment
    /// 
    /// </summary>
    public class Vehicle
    {
        public int X;
        public int Y;
        public Direction Direction;
        public Vehicle()
        {
            //Position validation of vehicle at startpoint with X and Y.
            do
            {
                Write("Starting position of the monstertruck (in terms of X {space} Y (e.g: 0 0)): ");
                var position = ReadLine();
                try
                {
                    //Validation of the position input as (X value, Y value.)
                    Pass = int.TryParse(position.Split(' ')[0], out X)
                          && int.TryParse(position.Split(' ')[1], out Y)
                          && X >= 0 && Y >= 0;
                }

                catch
                {
                    Pass = false;
                }

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid coordinators. Please try again.";
            } while (!Pass);


            //parsing vehicle direction at startpoint.
            do
            {
                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
                Pass = Enum.TryParse(ReadLine(), out Direction);

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid direction. Please try again.";
            } while (!Pass);
        }
        /// <summary>
        ///Boolean lookup. Checking if the startpoint of the vehicle inside the surface.
        /// 
        /// </summary>
        /// <param name="surface"></param>
        /// <returns></returns>
        public bool IsInsideSurface(Surface surface)
        {
            return X < surface.Width && Y < surface.Length;
        }

        //Start moving steps, command validation width, lengths VS x, y.
        public bool Move(Surface surface, ref List<Command> commands)
        {
            Pass = IsInsideSurface(surface);
            if (!Pass)
            {
                ErrorMessage = "ERROR: The vehicle located outside the surface dimensions.";
                return false;
            }

            //Commands counter, if the user would multiple commands.
            var counter = 1;

            //Commands process 
            foreach (var command in commands)
            {
                switch (command)
                {
                    //parsing forward step.
                    case Command.Forward:
                        WriteLine($"Step {counter++}, Going forward.");
                        X += Direction == Direction.East ? 1 : Direction == Direction.West ? -1 : 0;
                        Y += Direction == Direction.North ? 1 : Direction == Direction.South ? -1 : 0;
                        break;

                    //parsing Backward step.
                    case Command.Backward:
                        WriteLine($"Step {counter++}, Going backward.");
                        X += Direction == Direction.East ? -1 : Direction == Direction.West ? 1 : 0;
                        Y += Direction == Direction.North ? -1 : Direction == Direction.South ? 1 : 0;
                        break;

                    //parsing rotate right step. NOTE: the percentage symbol-
                    //sets the validate of the enums directions, so it must read only the first 4 values (0, 1, 2, 3)-
                    //of the DirectionEnum class.
                    case Command.RotateRight:
                        WriteLine($"Step {counter++}: Rotating 90° to the right.");
                        Direction = (Direction)(((byte)Direction + 1) % 4);
                        break;

                    // parsing rotate left step. NOTE: DirectionEnum has 4 values, 
                    // North = step 0, East = step 1, South = step 2, West = step 3.
                    // e.g: if the user chooes the direction to East and gave a command Left,
                    // then the process would be East + 3 efter step 1. Then direction will be to the North.
                    case Command.RotateLeft:
                        WriteLine($"Step {counter++}, Rotating 90° to the left.");
                        Direction = (Direction)(((byte)Direction + 3) % 4);
                        break;
                }

                //Validation of vehicle movement. (e.g if the vehicle hit a wall )
                Pass = !(X >= surface.Width || Y >= surface.Length || X < 0 || Y < 0);
                if (!Pass)
                    return false;
                else
                    WriteLine($"Current position (X  Y): ({X} {Y}), Direction is: {Direction}");
            }

            return true;
        }
    }
}
