using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KeystrokeAnalyzer.Support
{
    internal static class Deserializer
    {
        public static IEnumerable<Sample> FromFile(string filename) =>
            from line in File.ReadLines(filename)
            where !string.IsNullOrWhiteSpace(line)
            let split = line.Split(',')
            select new Sample(
                split[0].Trim(),
                int.Parse(split[1]),
                int.Parse(split[2])
            );

        public static IEnumerable<SampleSet> FromDirectory(string directory) =>
            from file in Directory.EnumerateFiles(directory)
            select new SampleSet(
                GetIdFromFilename(file),
                FromFile(file)
            );

        private static int GetIdFromFilename(string filepath) =>
            int.Parse(Path.GetFileName(filepath).Substring(1, 2));
    }
}
