using System;

namespace ComputerVision
{
    public interface ILogger
    {
        void Log(string text);
        void LogEx(Exception ex);
    }
}