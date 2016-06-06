using System;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    public class Processor : GenericDefaultProcessor
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        List<CycleList> cycleList = new List<CycleList>();

        public Processor(
            IMathObjectStack stack,
            IMathScope scope,
            FunctionRegistry registry)
            : base(stack, scope, registry)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
        }

        protected override IMathOperation Divide()
        {
            return new Compose();
        }

        protected override IMathOperation Multiply()
        {
            return new Compose();
        }

        protected override IMathOperation ExponentOperation()
        {
            return new Compose();
        }

        public IMathObjectStack Stack
        {
            get { return this.stack; }
        }

        public IMathObjectStack StackClone
        {
            get { return this.stackClone; }
        }

        public IMathScope Scope
        {
            get { return this.scope; }
        }

        public IMathObject VisitCompose(
            PermutationParser.ComposeContext context)
        {
            if (stack.Size < 2)
            {
                //ErrorHandler.SendError(this, "not enough arguments");
                return null;
            }

            stack.Push(new Compose());

            return stack.Top;
        }

        public IMathObject VisitInitCycle(
            IRuleNode node, 
            IParseTreeVisitor<IMathObject> visitor)
        {
            IMathObject result = null;

            int index = 0;
            for(int i = 0; i < node.ChildCount; i++)
            {
                var cycle = node.GetChild(i);

                result = visitor.Visit(cycle);

                if (index > 0)
                {
                    stack.Push(new Compose());
                }

                index++;
            }

            return result;
        }

        public IMathObject VisitCycle(
            IRuleNode node, 
            IParseTreeVisitor<IMathObject> visitor)
        {
            var list = new List<int>();

            for(int i = 0; i < node.RuleContext.ChildCount; i++)
            {
                var v = node.GetChild(i) as PermutationParser.ValueContext;

                if (v != null)
                {
                    int temp;
                    int.TryParse(v.INT().GetText(), out temp);
                    list.Add(temp);
                }
            }

            var cycle = CycleList.Create(list.ToArray());

            cycleList.Add(cycle);

            var obj = new MathObject(cycle.ToMatrix());

            this.stack.Push(obj);

            return obj;
        }
    }
}

