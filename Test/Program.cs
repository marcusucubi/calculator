using System;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.Symmetric;
using MathObjects.Framework;
using System.Diagnostics;
using MathObjects.Core.Matrix.Permutation;
using MathObjects.Core.Matrix;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var cycle = CycleList.Create("(1 2 3 4)");

            var matrix = new PermutationMatix(4);

            for (int i = 0; i < 4; i++)
            {
                matrix = matrix.MultiplyBy(cycle.ToMatrix());
            }

            var id = IntegerMatrix.GetIdentity(4);

            Debug.Assert(id.Equals(matrix));
        }
    }
}
