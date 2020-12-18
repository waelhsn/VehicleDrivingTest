using System;

namespace MonsterTruckDrivingTest.Helper
{
    public static class EnvironmentHelper
    {
        public static bool Pass = true;

        //Setting a helper to display the error of all inputs.
        private static string _errorMessage;
        public static string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                Pass = string.IsNullOrEmpty(value);
                _errorMessage = value;
                WriteLine(_errorMessage);
            }
        }

        //Creating a shortcuts for Console Write/Read.
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static bool Write(string output)
        {
            Console.Write(output);
            return true;
        }

        public static bool WriteLine(string output)
        {
            Console.WriteLine(output);
            return true;
        }
    }
}
