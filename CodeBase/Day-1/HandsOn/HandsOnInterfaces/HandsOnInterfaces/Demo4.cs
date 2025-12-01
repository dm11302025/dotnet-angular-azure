using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnInterfaces_Demo4
{
    //Logging (Domain: Application Monitoring)
    //Imagine you want to log messages either to File, Database, or Cloud.
    public interface ILogger
    {
        void Log(string message);
    }
    //Implementations
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to File: {message}");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to Database: {message}");
        }
    }

    public class CloudLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to Cloud: {message}");
        }
    }
    class Program
    {
        static void Main()
        {
            //Usage
            ILogger logger;

            logger = new FileLogger();
            logger.Log("System started");

            logger = new CloudLogger();
            logger.Log("Error occurred!");
        }
    }

    /*
     Real-World Analogy

    An interface is like a remote control:

    The TV, AC, or Music System may have different internal mechanisms.

    But all devices must respond to PowerOn() and PowerOff().

    You (user) don’t care about internal circuits. You just press the button.
     */
}
