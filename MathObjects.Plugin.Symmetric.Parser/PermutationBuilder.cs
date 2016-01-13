using System;
using MathObjects.Core.Matrix.Permutation;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class PermutationBuilder : PermutationBaseListener
    {
        PermutationMatix matrix;

        List<int> list = new List<int>();

        public PermutationMatix PermutationMatix
        {
            get { return this.matrix; }
        }

        public override void ExitInit(PermutationParser.InitContext context)
        {
            matrix = PermutationMatix.Create(list.ToArray());
        }

        public override void ExitValue(PermutationParser.ValueContext context)
        {
            list.Add(int.Parse(context.GetText()));
        }
    }
}

