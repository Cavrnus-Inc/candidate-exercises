namespace WebRtc
{
    public class AudioLevelChangedEventArgs
    {
        public string UserId { get; internal set; }
        public double Level { get; internal set; }
    }
}