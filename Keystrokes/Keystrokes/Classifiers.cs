using System;
using System.Linq;

namespace Keystrokes
{
    public static class Classifiers
    {
        public static int Euclidean(int[] first, int[] second) =>
            (int)Math.Round(Math.Sqrt(first.Zip(second, (i, j) => i - j).Sum(i => i * i)));

        public static int Manhattan(int[] first, int[] second) =>
            first.Zip(second, (i, j) => i > j ? i - j : j - i).Sum();

        public static int Chebyshev(int[] first, int[] second) =>
            first.Zip(second, (i, j) => i > j ? i - j : j - i).Max();
    }
}
