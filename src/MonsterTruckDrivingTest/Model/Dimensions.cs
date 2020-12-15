//using System;
//using System.Collections.Generic;
//using System.Text;
//using static System.Console;

//namespace MonsterTruckDrivingTest.Model
//{
//    public class Dimensions
//    {

//        public static void DimensionsBuilder()
//        {
//            var surface = new Surface();

//           // VehicleDrivingTest

//            Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

//            var dimensions = ReadLine();
//            if (dimensions.Contains(',') &&
//                int.TryParse(dimensions.Split(',')[0],
//                out surface.Width) &&
//                int.TryParse(dimensions.Split(',')[1],
//                out surface.Length) &&
//                surface.Width > 0 && surface.Length > 0)
//                surface.Pass = true;
//            else
//                WriteLine("ERROR. Invalid dimensions. Please try again.");
//        }
//    }
//}
