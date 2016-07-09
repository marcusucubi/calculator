using System;
using System.Diagnostics;
using MathObjects.Framework.Parser;
using MathObjects.Framework;
using Antlr4.Runtime.Tree;
using MathObjects.Plugin.FloatingPoint2;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Processor : GenericDefaultProcessor
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        public Processor(
            IMathObjectStack stack,
            IMathScope scope,
            IFunctionRegistry registry)
            : base(stack, scope, registry)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
        }

        protected override IMathOperation Divide()
        {
            return new Instruction("divide", 2);
        }

        protected override IMathOperation Multiply()
        {
            return new Instruction("multiply", 2);
        }

        protected override IMathOperation ExponentOperation()
        {
            return new Instruction("exponent", 2);
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

        public IMathObject VisitNegative(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            visitor.Visit(node.RuleContext.GetChild(1));

            return this.Stack.Push(new Instruction("additive inverse", 1));
        }

        public IMathObject VisitFloat(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            string param = node.GetChild(0).GetText();

            var result = new Data(param);
            Stack.Push(result);

            return result;
        }

        public IMathObject VisitInt(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            string param = node.GetChild(0).GetText();

            var result = new Data(param);
            Stack.Push(result);

            return result;
        }

        public IMathObject VisitValue(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            string param = node.GetChild(0).GetText();

            var result = new Data(param);
            Stack.Push(result);

            return result;
        }

        public IMathObject VisitAddSub(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            visitor.Visit(node.GetChild(2));
            visitor.Visit(node.GetChild(0));

            IMathOperation op = null;

            if (node.GetChild(1).GetText() == "+")
            {
                op = new Instruction("add", 2);
            }
            else
            {
                op = new Instruction("subtract", 2);
            }

            var result = Stack.Push(op);

            return result;
        }
    }
}

