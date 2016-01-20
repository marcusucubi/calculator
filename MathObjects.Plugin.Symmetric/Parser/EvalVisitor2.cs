using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class EvalVisitor2 : PermutationBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

//        readonly FactoryRegistry registry;

//        readonly IMathObject top;

        List<CycleList> cycleList = new List<CycleList>();

        public EvalVisitor2(
            FactoryRegistry registry, 
            IMathObjectStack stack)
        {
//            this.registry = registry;
            this.stack = stack;
//            this.top = this.stack.Top;
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

            this.stack.Enter(obj);

            return obj;
        }

        public override IMathObject VisitInit(PermutationParser.InitContext context)
        {
            IMathObject result = null;

            int index = 0;
            foreach (var cycle in context.cycle().Reverse())
            {
                result = Visit(cycle);

                if (index > 0)
                {
                    stack.Perform(new Compose());
                }

                index++;
            }

            return result;

            //var result = new MathObject() as IMathObject;
/*
            if (this.cycleList.Count > 1)
            {
                var compose = new Compose();

                var c1 = new MathObject(this.cycleList[0].ToMatrix());
                var c2 = new MathObject(this.cycleList[1].ToMatrix());

                result = compose.Perform(c1, c2);

                this.stack.Perform(compose);
            }
*/
//            return result;
        }
    }
}

