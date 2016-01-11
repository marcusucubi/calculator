using System;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.Symmetric;
using MathObjects.Framework;
using System.Diagnostics;
using MathObjects.Core.Matrix.Permutation;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var switches = new int[] { 2, 1, 3, 4 };
            var matrix = PermutationMatix.Create(switches);

            var switches2 = new int[] { 1, 2, 4, 3 };
            var matrix2 = PermutationMatix.Create(switches2);

            Debug.Assert(matrix.Height == 4);

            {
                var row = matrix.Switches;
                Debug.Assert(2 == row[0]);
                Debug.Assert(1 == row[1]);
                Debug.Assert(3 == row[2]);
                Debug.Assert(4 == row[3]);
            }

            var result = matrix.MultiplyBy(matrix2);
            {
                var row = result.Switches;
                Debug.Assert(2 == row[0]);
                Debug.Assert(1 == row[1]);
                Debug.Assert(4 == row[2]);
                Debug.Assert(3 == row[3]);
            }

            var cycle = CycleList.Create(result);
            var s = cycle.ToString();

            Console.Write(s);
        }
    }
}
