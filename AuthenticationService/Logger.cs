using System;

namespace AuthenticationService
{
    public class Logger
    {
        public void WriteEvent(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
