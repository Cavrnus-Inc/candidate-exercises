using System;
using System.Collections.Generic;
using System.Linq;
using WebRtc;

namespace AudioNormalizer
{
    public class AudioLogger : IAudioProcessor
    {
        private List<Tuple<double, string, ConsoleColor>> _statusMap = new List<Tuple<double, string, ConsoleColor>>() 
        { 
            new Tuple<double, string, ConsoleColor>(80, "very loud", ConsoleColor.Red),
            new Tuple<double, string, ConsoleColor>(60, "loud", ConsoleColor.Yellow),
            new Tuple<double, string, ConsoleColor>(40, "normal", ConsoleColor.Green),
            new Tuple<double, string, ConsoleColor>(20, "soft", ConsoleColor.DarkYellow),
            new Tuple<double, string, ConsoleColor>(0, "very soft", ConsoleColor.DarkRed),
        };

        public void OnAudioLevelChanged(string userId, double level)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (level > 0)
            {
                var status = _statusMap.First(s => level > s.Item1);
                Console.Write($"{userId} is talking\t:");
                Console.ForegroundColor = status.Item3;
                Console.WriteLine($" {level:N0} ({status.Item2})");
            }
            else
            {
                Console.WriteLine($"{userId} is slient");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
      
    }
}