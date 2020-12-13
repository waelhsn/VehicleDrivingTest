using static System.Console;

namespace MonsterTruckDrivingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("* * * Welcome to Monster Truck driving test * * *");
                VehicleDrivingTest.SurfacAndDrivingBuilder();
            }
        }
    }
}