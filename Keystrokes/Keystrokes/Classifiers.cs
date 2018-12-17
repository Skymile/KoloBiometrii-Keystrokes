using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Proceduralne
        //int sum = 0;
        //for (int i = 0; i < first.Length; i++)
        //    sum += (first[i] - second[i]) * (first[i] - second[i]);
        //return (int)Math.Round(Math.Sqrt(sum));
    }
}
