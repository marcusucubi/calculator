using NUnit.Framework;
using System;

namespace MathObjects.Core.Matrix.Permutation.Tests
{
    [TestFixture()]
    public class PermutationMatixTest
    {
        [Test]
        public void TestCase()
        {
            var switches = new int[] { 1, 2, 3 };
            var matrix = PermutationMatix.Create(switches);

            Assert.AreEqual(matrix.Height, 3);

            var row = matrix.Rows[0];
            Assert.AreEqual(row[0].Value, 1);
            Assert.AreEqual(row[1].Value, 0);
            Assert.AreEqual(row[2].Value, 0);
        }

        [Test]
        public void TestCase2()
        {
            var matrix = new PermutationMatix(3);

            Assert.AreEqual(matrix.Height, 3);

            var row = matrix.Rows[0];
            Assert.AreEqual(row[0].Value, 1);
            Assert.AreEqual(row[1].Value, 0);
            Assert.AreEqual(row[2].Value, 0);
        }

        [Test]
        public void TestCase3()
        {
            var matrix0 = new PermutationMatix(3);
            var matrix = new PermutationMatix(matrix0);

            Assert.AreEqual(matrix.Height, 3);

            var row = matrix.Rows[0];
            Assert.AreEqual(row[0].Value, 1);
            Assert.AreEqual(row[1].Value, 0);
            Assert.AreEqual(row[2].Value, 0);
        }

        [Test]
        public void TestCase4()
        {
            var matrix = new PermutationMatix(3);

            Assert.AreEqual(matrix.Height, 3);

            var row = matrix.Switches;
            Assert.AreEqual(1, row[0]);
            Assert.AreEqual(2, row[1]);
            Assert.AreEqual(3, row[2]);
        }

        [Test]
        public void TestCase5()
        {
            var matrix = new PermutationMatix(3);

            Assert.AreEqual(matrix.Height, 3);

            var row = matrix.Switches;
            Assert.AreEqual(1, row[0]);
            Assert.AreEqual(2, row[1]);
            Assert.AreEqual(3, row[2]);
        }

        [Test]
        public void TestCase6()
        {
            var switches = new int[] { 2, 1, 3, 4 };
            var matrix = PermutationMatix.Create(switches);

            var switches2 = new int[] { 1, 2, 4, 3 };
            var matrix2 = PermutationMatix.Create(switches2);

            Assert.AreEqual(matrix.Height, 4);

            {
                var row = matrix.Switches;
                Assert.AreEqual(2, row[0]);
                Assert.AreEqual(1, row[1]);
                Assert.AreEqual(3, row[2]);
                Assert.AreEqual(4, row[3]);
            }

            var result = matrix.MultiplyBy(matrix2);
            {
                var row = result.Switches;
                Assert.AreEqual(2, row[0]);
                Assert.AreEqual(1, row[1]);
                Assert.AreEqual(4, row[2]);
                Assert.AreEqual(3, row[3]);
            }


        }
    }
}

