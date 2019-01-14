using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Keystrokes.Tests
{
    [TestClass()]
    public class ClassifiersTests
    {
        private readonly int[] first = { 15, 30, 20, 0 };
        private readonly int[] second = { 5, 70, 25, 11 };

        private void DistanceTest(Func<int[], int[], int> distance, int value)
        {
            Assert.AreEqual(distance(this.first, this.first), 0);
            Assert.AreEqual(distance(this.first, this.second), value);
            Assert.AreEqual(distance(this.second, this.first), value);
            Assert.AreEqual(distance(this.second, this.second), 0);
        }
         
        [TestMethod()]
        public void EuclideanTest() => DistanceTest(Classifiers.Euclidean, 43);

        [TestMethod()]
        public void ManhattanTest() => DistanceTest(Classifiers.Manhattan, 66);

        [TestMethod()]
        public void ChebyshevTest() => DistanceTest(Classifiers.Chebyshev, 40);
    }
}