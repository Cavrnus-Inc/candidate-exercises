namespace WebRtc
{
    internal class UserAudioLevel
    {
        internal double BaseLevel { get; set; }
        public double LastLevel { get; set; }
        public double Gain { get; set; }

        public UserAudioLevel(double baseLevel)
        {
            BaseLevel = baseLevel;
        }
    }
}