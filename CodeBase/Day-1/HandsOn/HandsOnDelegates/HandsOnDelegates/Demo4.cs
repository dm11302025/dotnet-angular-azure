using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnDelegates_Demo4
{
    //For Callback Methods (Asynchronous or Event-based)
    public delegate void Notify();

    public class Downloader
    {
        public void StartDownload(Notify onComplete)
        {
            Console.WriteLine("Downloading...");
            Thread.Sleep(1000);
            onComplete(); // Callback when done
        }
    }

    class Program
    {
        static void Main()
        {
            Downloader d = new Downloader();
            d.StartDownload(() => Console.WriteLine("Download complete!"));
        }
        //Used in asynchronous programming or background tasks where you
        //notify once something is done.
    }

}
