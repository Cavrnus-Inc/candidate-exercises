using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WebRtc
{
    public sealed class WebRtcClient : IDisposable
    {
        private readonly object _lock = new Object();
        private Random _rng { get; }

        public EventWaitHandle _stopHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        private Dictionary<string, UserAudioLevel> _userData = new Dictionary<string, UserAudioLevel> {
            { "Leonardo", new UserAudioLevel(50)},
            { "Raphael", new UserAudioLevel(70)},
            { "Donatello", new UserAudioLevel(30)}
        };

        public List<IAudioProcessor> AudioProcessors { get; private set; }

        public WebRtcClient()
        {
            _rng = new Random();
            AudioProcessors = new List<IAudioProcessor>();
        }

        public Task Connect()
        {
            Task.Run(RunEmitter);

            return Task.Delay(_rng.Next(1000));
        }

        public Task Disconnect()
        {
            _stopHandle.Set();

            return Task.Delay(_rng.Next(1000));
        }

        public void Dispose()
        {
            Disconnect();
        }

        public Task<string> GetAudioReport()
        {
            return Task.Delay(_rng.Next(1000)).ContinueWith(t =>
            {
                lock (_lock)
                {
                    return JsonSerializer.Serialize(_userData);
                }
            });
        }

        public double GetUserGain(string userId)
        {
            return _userData[userId].Gain;
        }

        private void NotifyAudioLevelChanged()
        {
            var index = _rng.Next(_userData.Count);
            KeyValuePair<string, UserAudioLevel> userDatum;
            lock (_lock)
            {
                userDatum = _userData.ElementAt(index);
            }

            var flux = 8;

            foreach (var audioProcessor in AudioProcessors)
            {
                var level = Math.Max(5, Math.Min(100, userDatum.Value.BaseLevel + userDatum.Value.Gain + _rng.Next(-flux, flux)));
                userDatum.Value.LastLevel = level;

                audioProcessor.OnAudioLevelChanged(userDatum.Key, level);
            }
        }

        public void SetUserGain(string userId, double gain)
        {
            lock (_lock)
            {
                _userData[userId].Gain = gain;
            }
        }

        private void RunEmitter()
        {
            while (!_stopHandle.WaitOne(_rng.Next(2000)))
            {
                Task.Run(NotifyAudioLevelChanged);
            }
        }
    }
}
