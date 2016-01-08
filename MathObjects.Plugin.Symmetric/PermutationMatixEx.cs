using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Core.Matrix;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    public static class PermutationMatixEx
    {
        public static IntegerMatrix Expand(this IntegerMatrix matrix, uint count)
        {
            int[] switches = new PermutationMatix(matrix).Switches;

            var list = new LinkedList<int>(switches);

            int index = switches.Length;
            for (int i = 0; i < count; i++)
            {
                list.AddLast(index + 1);
                index++;
            }

            return PermutationMatix.Create(list.ToArray());
        }
    }
}

