using static System.Console;

namespace MonsterTruckDrivingTest.Model
{
    public class DimensionsPositionsCrator
    {
        public int width =  new SurfaceProperties().Width;
        public int length =  new SurfaceProperties().Length;
        public int X = new Position().X;
        public int Y = new Position().Y;

        public void CreateNewDimensions()
        {
            var vehicle = new VehicleProperties();
            Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");
            var dimensions = ReadLine();
            try
            {
                int.TryParse(dimensions.Split(',')[0], out int widthValue);
                int.TryParse(dimensions.Split(',')[1], out int lengthValue);
                width = widthValue;
                length = lengthValue;
            } catch { }

            if (dimensions.Contains(',') &&
                int.TryParse(dimensions.Split(',')[0], out _) &&
                int.TryParse(dimensions.Split(',')[1], out _) &&
                width > 0 && length > 0)
                vehicle.Pass = true;
            else
                WriteLine("ERROR. Invalid dimensions. Please try again.");
        }

        public void CreateNewPosition()
        {
            var vehicle = new VehicleProperties();
            var vehiclePosition = new Position();
            Write($"Starting position of the monstertruck (in terms of X and Y (e.g: 0,0)): ");
            var position = ReadLine();
            try
            {
                int.TryParse(position.Split(',')[0], out int xValue);
                int.TryParse(position.Split(',')[1], out int yValue);
                X = xValue;
                Y = yValue;
            } catch { }

            if (position.Contains(',') &&
                int.TryParse(position.Split(',')[0], out _) &&
                int.TryParse(position.Split(',')[1], out _) &&
                vehiclePosition.X >= 0 && vehiclePosition.Y >= 0 &&
                vehiclePosition.X <= width - 1 && vehiclePosition.Y <= width - 1)
                vehicle.Pass = true;
            else
                WriteLine("ERROR. Invalid coordinators. Please try again.");
        }
    }
}