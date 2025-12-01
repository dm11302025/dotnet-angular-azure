using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Events
{
    // Defines what kind of methods can handle this event
    public delegate void DownloadCompletedHandler(string fileName);
    //Create a Publisher (Event Source)
    //This class publishes an event — meaning, it raises the event when something happens.
    public class FileDownloader
    {
        // Step 2.1: Declare an event based on the delegate
        public event DownloadCompletedHandler DownloadCompleted;

        // Step 2.2: Method that does the work
        public void DownloadFile(string fileName)
        {
            Console.WriteLine($"Downloading {fileName}...");
            Thread.Sleep(2000); // Simulate download time

            // Step 2.3: Raise (trigger) the event after completion
            OnDownloadCompleted(fileName);
        }

        // Protected virtual method to raise the event
        protected virtual void OnDownloadCompleted(string fileName)
        {
            // Check if there are any subscribers (to avoid null reference)
            if (DownloadCompleted != null)
                DownloadCompleted(fileName);
        }
    }
    //Create Subscribers (Listeners)
    //Subscribers are classes or methods that want to respond to the event.
    public class Logger
    {
        public void LogDownload(string fileName)
        {
            Console.WriteLine($"[Logger] File downloaded: {fileName}");
        }
    }

    public class Notifier
    {
        public void NotifyUser(string fileName)
        {
            Console.WriteLine($"[Notifier] Sending notification for {fileName}");
        }
    }
    //Wire Everything Together (Main Program)
    class Program
    {
        static void Main()
        {
            FileDownloader downloader = new FileDownloader();
            Logger logger = new Logger();
            Notifier notifier = new Notifier();

            // Subscribe to the event
            downloader.DownloadCompleted += logger.LogDownload;
            downloader.DownloadCompleted += notifier.NotifyUser;

            // Start download
            downloader.DownloadFile("MyDocument.pdf");
        }
    }


}
