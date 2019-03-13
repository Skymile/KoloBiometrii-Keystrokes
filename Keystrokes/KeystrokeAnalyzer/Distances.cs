using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeystrokeAnalyzer
{
    public delegate double Distance(IEnumerable<double> first, IEnumerable<double> second);

    static class Distances
    {
        public static double Euclidean(IEnumerable<double> first, IEnumerable<double> second) =>
            Math.Sqrt(first.Zip(second, (i, j) => i - j).Sum(k => k * k));

        public static double Manhattan(IEnumerable<double> first, IEnumerable<double> second) =>
            first.Zip(second, (i, j) => Math.Abs(i - j)).Sum();

        public static double Chebyshev(IEnumerable<double> first, IEnumerable<double> second) =>
            first.Zip(second, (i, j) => Math.Abs(i - j)).Max();
    }
}
