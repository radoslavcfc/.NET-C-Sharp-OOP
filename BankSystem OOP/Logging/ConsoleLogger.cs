using System;

namespace Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Assert(bool condition, string message)
        {
            if (condition)
            {
                Console.WriteLine(message);
            }
        }

        public void Debug(string message)
        {
            Console.WriteLine("Debug info: " + message);
        }

        public void Error(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void Fatal(string message)
        {
            Console.WriteLine("Fatal Error: " + message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Trace(string message)
        {
            Console.WriteLine("Trace: " + message);
        }

        public void Warn(string message)
        {
            Console.WriteLine("Warning: " + message);
        }
    }
}
