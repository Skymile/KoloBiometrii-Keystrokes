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

        public static Keystroke FromString(string line)
        {
            string[] split = line.Split(',');

            return new Keystroke(
                int.Parse(split[1].Trim()),
                int.Parse(split[2].Trim()),
                split[0].Trim()
            );
        }

        public override string ToString() =>
            $"{this.Key}, {this.Dwell}, {this.Flight}";

        public readonly int Dwell;
        public readonly int Flight;
        public readonly string Key;
    }
}