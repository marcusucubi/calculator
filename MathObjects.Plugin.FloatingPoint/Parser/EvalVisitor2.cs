using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor2 : EvalVisitor1
    {
        public EvalVisitor2(
            IMathObjectStack stack,
            IMathScope scope,
            InitVisitor init)
            : base(stack,scope,init)
        {
        }

        public override IMathObject VisitNegative(
            FloatingPointParser.NegativeContext context)
        {
            Visit(context.expr());

            var result = this.Stack.Push(new Negative());

            Debug.WriteLine("VisitNegative");

            return result;
        }

        public override IMathObject VisitFloat(
            FloatingPointParser.FloatContext context)
        {
            double temp;
            double.TryParse(context.FLOAT().GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitFloat [" + result + "]");

            return result;
        }

        public override IMathObject VisitInt(
            FloatingPointParser.IntContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitInt [" + result + "]");

            return result;
        }

        public override IMathObject VisitValue(
            FloatingPointParser.ValueContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            Stack.Push(result);

            Debug.WriteLine("VisitValue [" + result + "]");

            return result;
        }

        public override IMathObject VisitAddSub(
            FloatingPointParser.AddSubContext context)
        {
            Debug.WriteLine("Start VisitAddSub []");

            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            IMathOperation op = null;

            if (context.op.Type == FloatingPointParser.ADD)
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

