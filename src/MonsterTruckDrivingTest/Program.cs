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
              //  var gearBox = new GearBox();
                var dimensionsPositionsCrator = new DimensionsPositionsCrator();

                //Input and validation of surface width and length.
                do
                {
                    dimensionsPositionsCrator.CreateNewDimensions();
                } while (!dimensionsPositionsCrator.pass);

                //Input and validation of x, y positions.
                dimensionsPositionsCrator.pass = false;
                do
                {
                    dimensionsPositionsCrator.CreateNewPosition();
                } while (!dimensionsPositionsCrator.pass);

                //Input and validation of direction.
                dimensionsPositionsCrator.pass = false;

               // Directions initialDirection;
                do
                {
                    dimensionsPositionsCrator.DirectionsValidation();
                } while (!dimensionsPositionsCrator.pass);

                // the commands.
                dimensionsPositionsCrator.GearStick();
                
            }
        }
    }
}