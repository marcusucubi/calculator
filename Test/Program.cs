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
            var switches = new int[] { 1, 2, 3 };
            var matrix = PermutationMatix.Create(switches);

            Debug.Assert(matrix.Height == 3);

            var row = matrix.Rows[0];
            Debug.Assert(row[0].Value == 1);
            Debug.Assert(row[1].Value == 0);
            Debug.Assert(row[2].Value == 0);
        }
    }
}
