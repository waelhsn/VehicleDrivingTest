using static MonsterTruckDrivingTest.Helper.EnvironmentHelper;

namespace MonsterTruckDrivingTest.Model
{
    public class Surface
    {
        public int Width;
        public int Length;
        public Surface()
        {
            //Dimensions validation of the sureface for the width and length.
            do
            {
                Write("Width and length of the surface (in terms of Width {space} Length (e.g: 10 10)): ");
                var dimensions = ReadLine();
                try
                {
                    //Validation of the dimensions input as (Width value, Length value.)
                    Pass = int.TryParse(dimensions.Split(' ')[0], out Width) &&
                           int.TryParse(dimensions.Split(' ')[1], out Length) &&
                        Width > 0 && Length > 0;
                }

                catch
                {
                    Pass = false;
                }

                if (!Pass)
                    ErrorMessage = "ERROR. Invalid dimensions. Please try again.";
            } while (!Pass);
        }
    }
}
