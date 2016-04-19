using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.Matrix.Permutation;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class EvalVisitor2 : PermutationBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        List<CycleList> cycleList = new List<CycleList>();

        public EvalVisitor2(IMathObjectStack stack)
        {
            this.stack = stack;
        }

        public override IMathObject VisitCompose(PermutationParser.ComposeContext context)
        {
            if (stack.Size < 2)
            {
                //ErrorHandler.SendError(this, "not enough arguments");
                return null;
            }

            stack.Push(new Compose());

            return stack.Top;
        }

        public override IMathObject VisitInitCycle(PermutationParser.InitCycleContext context)
        {
            IMathObject result = null;

            int index = 0;
            foreach (var cycle in context.cycle().Reverse())
            {
                result = Visit(cycle);

                if (index > 0)
                {
                    stack.Push(new Compose());
                }

                index++;
            }

            return result;
        }

        public override IMathObject VisitCycle(
            PermutationParser.CycleContext context)
        {
            var list = new List<int>();

            foreach (var v in context.value())
            {
                int temp;
                int.TryParse(v.INT().GetText(), out temp);
                list.Add(temp);
            }

            var cycle = CycleList.Create(list.ToArray());

            cycleList.Add(cycle);

            var obj = new MathObject(cycle.ToMatrix());

            this.stack.Push(obj);

            return obj;
        }
    }
}

