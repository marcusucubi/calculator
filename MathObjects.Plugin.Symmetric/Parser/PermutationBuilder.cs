using System;
using System.Collections.Generic;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class PermutationBuilder : PermutationBaseListener
    {
        CycleList cycle;

        List<List<int>> bigList = new List<List<int>>();

        List<int> list = new List<int>();

        public PermutationMatix PermutationMatix
        {
            get { return this.cycle.ToMatrix(); }
        }

        public override void ExitCycle(PermutationParser.CycleContext context)
        {
            bigList.Add(list);
            list = new List<int>();
        }

        public override void ExitInit(PermutationParser.InitContext context)
        {
            cycle = CycleList.Create(bigList);
        }

        public override void ExitValue(PermutationParser.ValueContext context)
        {
            list.Add(int.Parse(context.GetText()));
        }
    }
}

