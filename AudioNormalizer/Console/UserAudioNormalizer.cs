using System;
using WebRtc;

namespace AudioNormalizer
{
    public class UserAudioNormalizer : IAudioProcessor
    {
        public void OnAudioLevelChanged(string userId, double audioLevel)
        {
            // TODO: Implement audio normalization
        }
    }
}