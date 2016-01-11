using NUnit.Framework;
using System;

namespace MathObjects.Core.Matrix.Permutation.Tests
{
    [TestFixture()]
    public class CycleListTest
    {
        [Test]
        public void TestCase1()
        {
            var cycle = CycleList.Create("(1 2 3 4)");

            var matrix = new PermutationMatix(4);

            for (int i = 0; i < 4; i++)
            {
                matrix = matrix.MultiplyBy(cycle.ToMatrix());
            }

            var id = IntegerMatrix.GetIdentity(4);

            Assert.AreEqual(id, matrix);
        }
    }
}

