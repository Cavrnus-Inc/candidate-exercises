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
            rtcClient.AudioProcessors.Add(new UserAudioNormalizer());

            Console.WriteLine("Connecting...");
            rtcClient.Connect();

            Console.WriteLine("Press <ENTER> to exit");
            Console.ReadLine();

            // TODO: Display audio report
        }
    }
}
