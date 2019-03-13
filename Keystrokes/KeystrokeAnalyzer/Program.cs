using System;
using System.Linq;

using KeystrokeAnalyzer.Support;

namespace KeystrokeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var samples = Deserializer.FromDirectory("Samples").ToArray();

            var distances =
                from i in typeof(Distances).GetMethods()
                where i.ReturnType == typeof(double)
                select (Distance)i.CreateDelegate(typeof(Distance));

            int length = 10;

            foreach (Distance dist in distances)
            {
                Console.Write(dist.Method.Name + " ");
                double[] accuracies = new double[length - 1];
                for (int k = 1; k < length; k++)
                    for (int m = 0; m < samples.Length; m++)
                    {
                        var i = samples[m];

                        int result = 
                            Classifiers.KNN(i, samples.Where(j => j != i).ToArray(), k, dist);

                        if (result == i.UserId)
                            ++accuracies[k - 1];
                    }

                foreach (double i in accuracies)
                    Console.Write($"{Math.Round(i / samples.Length * 100, 2)}% ");
                Console.WriteLine();
            }

            Console.ReadLine();
        }


    }
}
