using System.Collections.Generic;
using System.Linq;

namespace KeystrokeAnalyzer.Support
{
    class SampleSet
    {
        public SampleSet(int userId, IEnumerable<Sample> samples)
        {
            this.UserId = userId;
            this.Samples = samples.ToArray();
        }

        public int UserId { get; set; }
        public Sample[] Samples { get; set; }
        
        public double[] Dwells =>
            this.Samples.Select(i => (double)i.Dwell).ToArray();

        public double[] Flights =>
            this.Samples.Zip(
                this.Samples.Skip(1), 
                (i, j) => (double)(i.OnReleased - j.OnPressed)
            ).ToArray();
    }
}
