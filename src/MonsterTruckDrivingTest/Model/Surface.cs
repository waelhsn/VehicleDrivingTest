using static MonsterTruckDrivingTest.Helper.Shared;

namespace MonsterTruckDrivingTest.Model
{
    public class Surface
    {
        public int Width;
        public int Length;
        public Surface()
        {
            Write($"Width and length of the surface (in terms of Width, Length (e.g: 10,10)): ");

            //Dimensions validation of the sureface for the width and length.
            var dimensions = ReadLine();

            Pass = int.TryParse(dimensions.Split(',')[0], out Width) &&
                int.TryParse(dimensions.Split(',')[1], out Length) &&
                Width > 0 && Length > 0;

            if (!Pass)
                ErrorMessage = "ERROR. Invalid dimensions. Please try again.";
        }
    }
}
