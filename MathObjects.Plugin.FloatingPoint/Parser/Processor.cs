using System;
using System.Diagnostics;
using MathObjects.Framework.Parser;
using MathObjects.Framework;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Processor
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        public Processor(
            IMathObjectStack stack,
            IMathScope scope)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
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

            var result = this.Stack.Push(new Negative());

            Debug.WriteLine("VisitNegative");

            return result;
        }

        public IMathObject VisitFloat(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            double temp;
            double.TryParse(node.GetChild(0).GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitFloat [" + result + "]");

            return result;
        }

        public IMathObject VisitInt(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            double temp;
            double.TryParse(node.GetChild(0).GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitInt [" + result + "]");

            return result;
        }

        public IMathObject VisitValue(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            double temp;
            double.TryParse(node.GetChild(0).GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitValue [" + result + "]");

            return result;
        }

        public IMathObject VisitAddSub(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitAddSub []");

            var left = visitor.Visit(node.GetChild(2));
            var right = visitor.Visit(node.GetChild(0));

            IMathOperation op = null;

            if (node.GetChild(1).GetText() == "+")
            {
                op = new Add();
            }
            else
            {
                op = new Subtract();
            }

            var result = Stack.Push(op);

            Debug.WriteLine("End VisitAddSub [" + 
                left + "+" + right + "] [" + result.GetDouble() + "]");

            return result;
        }
    }
}

