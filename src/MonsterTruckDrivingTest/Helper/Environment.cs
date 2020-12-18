using System;

namespace MonsterTruckDrivingTest.Helper
{
    public class Environment
    {
        public bool Pass;
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                Pass = string.IsNullOrEmpty(value);
                _errorMessage = value;
                WriteLine(_errorMessage);
            }
        }

        public Environment()
        {
            Pass = true;
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public bool Write(string output)
        {
            Console.Write(output);
            return true;
        }

        public bool WriteLine(string output)
        {
            Console.WriteLine(output);
            return true;
        }
    }
}
