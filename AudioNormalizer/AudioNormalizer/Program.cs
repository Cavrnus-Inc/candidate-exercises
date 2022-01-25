using System;
using System.Threading;
using WebRtc;

namespace AudioNormalizer
{
    class Program
    {
        static void Main(string[] args)
        {
            using var rtcClient = new WebRtcClient();
            rtcClient.AudioProcessors.Add(new AudioLogger());

            Console.WriteLine("Simulation is running; press <ENTER> to exit.");

            Console.WriteLine("Connecting...");
            rtcClient.Connect();

            Console.ReadLine();

            // TASK: Display audio report
        }
    }
}
