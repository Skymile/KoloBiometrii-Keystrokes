using System;

namespace Keystrokes
{
    internal struct Keystroke
    {
        public Keystroke(int dwell, int flight, string key)
        {
            this.Dwell = dwell;
            this.Flight = flight;
            this.Key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public override string ToString() =>
            $"{this.Key}, {this.Dwell}, {this.Flight}";

        public readonly int Dwell;
        public readonly int Flight;
        public readonly string Key;
    }
}