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
        private readonly object _userDataLock = new();
        private bool _isConnected = false;
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
            Task.Run(RunSimulation);

            return Task.Delay(_rng.Next(1000)).ContinueWith(t => _isConnected = true);
        }

        public Task Disconnect()
        {
            _stopHandle.Set();

            return Task.Delay(_rng.Next(1000)).ContinueWith(t => _isConnected = false);
        }

        public void Dispose()
        {
            Disconnect();
        }

        public Task<string> GetAudioReport()
        {
            return Task.Delay(_rng.Next(1000)).ContinueWith(t =>
            {
                lock (_userDataLock)
                {
                    if (_isConnected)
                        throw new InvalidOperationException("WebRtcClient is disconnected");

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
            lock (_userDataLock)
            {
                userDatum = _userData.ElementAt(index);
            }

            var flux = 8;
            var isTalking = _rng.Next(100) > 25;

            var level = isTalking ? Math.Max(0, Math.Min(100, userDatum.Value.BaseLevel + userDatum.Value.Gain + _rng.Next(-flux, flux))) : 0;
            userDatum.Value.LastLevel = level;

            foreach (var audioProcessor in AudioProcessors)
            {
                audioProcessor.OnAudioLevelChanged(userDatum.Key, level);
            }
        }

        public void SetUserGain(string userId, double gain)
        {
            lock (_userDataLock)
            {
                _userData[userId].Gain = gain;
            }
        }

        private void RunSimulation()
        {
            while (!_stopHandle.WaitOne(_rng.Next(2000)))
            {
                Task.Run(NotifyAudioLevelChanged);
            }
        }
    }
}
