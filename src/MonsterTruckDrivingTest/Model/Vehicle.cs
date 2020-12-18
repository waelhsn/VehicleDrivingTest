﻿using static MonsterTruckDrivingTest.Helper.EnvironmentHelper;
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

            //Position validation of vehicle at startpoint with X and Y.
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

            //parsing vehicle direction at startpoint.
            do
            {
                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
                Pass = Enum.TryParse(ReadLine(), out Direction);

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid direction. Please try again.";
            } while (!Pass);
        }
        
        //Boolean lookup. Checking if the startpoint of the vehicle inside the surface.
        public bool IsInsideSurface(Surface surface)
        {
            return X < surface.Width && Y < surface.Length;
        }

        //Start moving steps, command validation width, lengs VS x, y.
        public bool Move(Surface surface, ref List<CommandEnum> commands)
        {
            Pass = IsInsideSurface(surface);
            if (!Pass)
            {
                ErrorMessage = "ERROR: Vehicle provided is outside surface dimensions.";
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
                    case CommandEnum.Forward:
                        WriteLine($"Step {counter++}, Going forward.");
                        X += Direction == DirectionEnum.East ? 1 : Direction == DirectionEnum.West ? -1 : 0;
                        Y += Direction == DirectionEnum.North ? 1 : Direction == DirectionEnum.South ? -1 : 0;
                        break;

                    //parsing Backward step.
                    case CommandEnum.Backward:
                        WriteLine($"Step {counter++}, Going backward.");
                        X += Direction == DirectionEnum.East ? -1 : Direction == DirectionEnum.West ? 1 : 0;
                        Y += Direction == DirectionEnum.North ? -1 : Direction == DirectionEnum.South ? 1 : 0;
                        break;

                    //parsing rotate right step. NOTE: the percentage symbol-
                    //sets the validate of the enums directions, so it must read only the first 4 values (0, 1, 2, 3)-
                    //of the DirectionEnum class.
                    case CommandEnum.RotateRight:
                        WriteLine($"Step {counter++}: Rotating 90° to the right.");
                        Direction = (DirectionEnum)(((byte)Direction + 1) % 4);
                        break;

                    // parsing rotate left step. NOTE: DirectionEnum has 4 values, 
                    // North = step 0, East = step 1, South = step 2, West = step 3.
                    // e.g: if the user chooes the direction to East and gave a command Left,
                    // then the process would be East + 3 efter step 1. Then direction will be to the North.
                    case CommandEnum.RotateLeft:
                        WriteLine($"Step  {counter++}, Rotating 90° to the left.");
                        Direction = (DirectionEnum)(((byte)Direction + 3) % 4);
                        break;
                }

                //Validation for selection start point position of the vehicle.
                Pass = !(X > surface.Width || Y > surface.Length || X < 0 || Y < 0);
                if (!Pass)
                    return false;
                else
                    WriteLine($"Current position (X, Y): ({X}, {Y}), Direction is: {Direction}");
            }

            return true;
        }
    }
}
