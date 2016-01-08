using System;
using System.Linq;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    public static class CycleNotationGenerator
    {
        static public string Generate(PermutationMatix matrix)
        {
            var builder = new CycleListBuilder2();

            var cycle = builder.Build(matrix);

            string s = "(";
            foreach(var pos in cycle.CycleSet)
            {
                s += " " + pos;
            }
            s += " )";

            return s;
        }
    }
}

