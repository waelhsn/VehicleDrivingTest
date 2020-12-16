
namespace MonsterTruckDrivingTest.Model
{
    public  class VehicleProperties
    {
        Directions Directions { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public int Width { 
            get {return 0; } 
            set { }
        }
        public int Length { get; set; }
        public bool Pass { get; set; }
       public string Commands { get; set; }
    }
}
