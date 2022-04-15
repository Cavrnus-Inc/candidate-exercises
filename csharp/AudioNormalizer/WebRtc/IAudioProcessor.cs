namespace WebRtc
{
    public interface IAudioProcessor
    {
        void OnAudioLevelChanged(string userId, double level);
    }
}