using MonsterTruckDrivingTest.Model;
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
                VehicleDrivingTest.SurfacAndDrivingBuilder();
            }
        }
    }
}