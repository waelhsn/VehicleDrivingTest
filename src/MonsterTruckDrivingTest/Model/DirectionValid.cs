//using System;
//using static System.Console;

//namespace MonsterTruckDrivingTest.Model
//{
//    public class DirectionValid
//    {
//        public static void DirctionVector( Surface surface)
//        {
           
//            Directions initialDirection;
//            do
//            {
//                Write($"Direction of the monstertruck at the start point (North, East, South or West): ");
//                bool isValid = Enum.TryParse(ReadLine(), out initialDirection);
//                if (isValid)
//                    surface.Pass = true;
//                else
//                    WriteLine("ERROR. Invalid direction. Please try again.");
//            } while (!surface.Pass);
//        }
//    }
//}
