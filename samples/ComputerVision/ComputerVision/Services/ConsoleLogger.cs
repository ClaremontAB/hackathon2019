using System;

namespace ComputerVision
{
    public class ConsoleLogger :ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }

        public void LogEx(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}