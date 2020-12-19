using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterTruckDrivingTest.Helper;
using MonsterTruckDrivingTest.Model;

namespace MonsterTruckDrivingTest.Tests
{
    [TestClass()]
    public class VehicleDrivingTestTests
    {
        [TestMethod()]
        public void SurfacAndDrivingBuilderTest()
        {

            var surface = new Surface();
            var vehicle = new Vehicle();

            EnvironmentHelper.Pass = vehicle.IsInsideSurface(surface);

            //Assert.IsTrue(vehicle.IsInsideSurface(surface), false.ToString());


        }
    }
};