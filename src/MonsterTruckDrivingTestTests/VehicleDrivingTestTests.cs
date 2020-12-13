using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MonsterTruckDrivingTest.Tests
{
    [TestClass()]
    public class VehicleDrivingTestTests
    {
        [TestMethod()]
        public void SurfacAndDrivingBuilderTest()
        {
            VehicleDrivingTest vehicleDrivingTest = new VehicleDrivingTest();
            vehicleDrivingTest.Equals(vehicleDrivingTest);
        }
    }
};