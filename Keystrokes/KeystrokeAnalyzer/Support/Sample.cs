using System;

namespace KeystrokeAnalyzer.Support
{
    public readonly struct Sample
    {
        public Sample(string key, int onPressed, int onReleased)
        {
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
            this.OnPressed = onPressed;
            this.OnReleased = onReleased;
        }

        public int Dwell => 
            this.OnReleased - this.OnPressed;

        public readonly string Key;
        public readonly int OnPressed;
        public readonly int OnReleased;
    }
}
