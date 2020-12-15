//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using static System.Console;

//namespace MonsterTruckDrivingTest.Model
//{
//    public class CommandsCreator
//    {
//        public static void CommandsBuilder( Surface surface, Directions initialDirection)
//        {
//            //string commands;
//            int x = 0, y = 0, currentX, currentY;

//            bool pass = true;

//            do
//            {
//                //Setting the allowed commands for this driving session.
//                var allowedCommands = new[] { 'F', 'B', 'R', 'L' };
//                Write("Commands to be executed for final driving result: ");
//                surface.Commands = ReadLine().ToUpper();

//                foreach (var command in surface.Commands)

//                    if (!allowedCommands.Contains(command))
//                        pass = false;

//                if (!pass)
//                    WriteLine("ERROR: Commands contain a character that doesn't belong to allowed set. Please try again.");

//            } while (!pass);
//            currentX = x;
//            currentY = y;

//            var currentDirection = initialDirection;

//            //Process the commands.
//            foreach (var command in surface.Commands)
//            {
//                //Commands switch of possibilities scenarios.
//                switch (command)
//                {
//                    //Steps cases
//                    case 'F':
//                        Write("Forwarded ");
//                        currentX += currentDirection == Directions.East ? 1 : currentDirection == Directions.West ? -1 : 0;
//                        currentY += currentDirection == Directions.North ? 1 : currentDirection == Directions.South ? -1 : 0;
//                        break;

//                    case 'B':
//                        Write("Backwarded ");
//                        currentX += currentDirection == Directions.East ? -1 : currentDirection == Directions.West ? 1 : 0;
//                        currentY += currentDirection == Directions.North ? -1 : currentDirection == Directions.South ? 1 : 0;
//                        break;

//                    //Rotation cases
//                    case 'R':
//                        Write("Rotating 90° to the right ");
//                        currentDirection += 1;
//                        break;

//                    case 'L':
//                        Write("Rotating 90° to the left, ");
//                        currentDirection = currentDirection == 0 ?
//                            Directions.West : currentDirection - 1;
//                        break;
//                }
//                WriteLine($"{currentX}, {currentY} as a postion, \nDirection: {currentDirection}");

//            }
//        }
//    }
//}
