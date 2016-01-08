using System;
using System.Collections.Generic;
using System.Linq;

namespace MathObjects.Plugin.Symmetric
{
    public static class CycleNotationParser
    {
        static public PermutationMatix Parse(string value)
        {
            var builder = new CycleListBuilder();

            var cycle = builder.Build(value);

            if (cycle.CycleSet.Count == 1)
            {
                return new PermutationMatix(PermutationMatix.GetIdentity(3));
            }

            return PermutationMatix.Create(cycle.PermutedList.ToArray());
        }
    }
}

