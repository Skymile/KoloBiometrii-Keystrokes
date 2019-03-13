using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeystrokeAnalyzer.Support;

namespace KeystrokeAnalyzer
{
    static class Classifiers
    {
        public static int KNN(SampleSet current, SampleSet[] training, int k, Distance distance) => (
            from j in (
                        from i in training
                        let dist = distance(current.Dwells, i.Dwells)
                        orderby dist
                        select (Distance: dist, Id: i.UserId)
                    ).Take(k)
                group j by j.Id into p
                orderby p.Count() descending
                select p.First()
            ).First().Id;
    }
}
