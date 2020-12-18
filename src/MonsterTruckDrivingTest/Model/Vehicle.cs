using static MonsterTruckDrivingTest.Helper.Shared;
using MonsterTruckDrivingTest.Helper;
using System.Collections.Generic;
using System;

namespace MonsterTruckDrivingTest.Model
{
    public class Vehicle
    {
        public int X;
        public int Y;
        public DirectionEnum Direction;
        public Vehicle()
        {
            do
            {
                Write($"Starting position of the monstertruck (in terms of X and Y (e.g: 0,0)): ");
                var position = ReadLine();

                Pass = int.TryParse(position.Split(',')[0], out X)
                    && int.TryParse(position.Split(',')[1], out Y)
                    && X >= 0 && Y >= 0;

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid coordinators. Please try again.";
            } while (!Pass);

            do
            {
                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
                Pass = Enum.TryParse(ReadLine(), out Direction);

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid direction. Please try again.";
            } while (!Pass);
        }
        
        public bool IsInsideSurface(Surface surface)
        {
            return X < surface.Width && Y < surface.Length;
        }

        public bool Move(Surface surface, ref List<CommandEnum> commands)
        {
            Pass = IsInsideSurface(surface);
            if (!Pass)
            {
                ErrorMessage = "ERROR: Vehicle provided is outside surface dimensions.";
                return false;
            }

            var counter = 1;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case CommandEnum.Forward:
                        WriteLine($"Step {counter++}- Going forward.");
                        X += Direction == DirectionEnum.East ? 1 : Direction == DirectionEnum.West ? -1 : 0;
                        Y += Direction == DirectionEnum.North ? 1 : Direction == DirectionEnum.South ? -1 : 0;
                        break;

                    case CommandEnum.Backward:
                        WriteLine($"Step {counter++}- Going backward.");
                        X += Direction == DirectionEnum.East ? -1 : Direction == DirectionEnum.West ? 1 : 0;
                        Y += Direction == DirectionEnum.North ? -1 : Direction == DirectionEnum.South ? 1 : 0;
                        break;

                    case CommandEnum.RotateRight:
                        WriteLine($"Step {counter++}- Rotating to the right.");
                        Direction = (DirectionEnum)(((byte)Direction + 1) % 4);
                        break;

                    case CommandEnum.RotateLeft:
                        WriteLine($"Step {counter++}- Rotating to the left.");
                        Direction = (DirectionEnum)(((byte)Direction + 3) % 4);
                        break;
                }

                //Validate changes done to the vehicle.
                Pass = !(X > surface.Width || Y > surface.Length || X < 0 || Y < 0);
                if (!Pass)
                    return false;
                else
                    WriteLine($"Current position: X={X}, Y={Y}, Direction={Direction}");
            }

            return true;
        }
    }
}
