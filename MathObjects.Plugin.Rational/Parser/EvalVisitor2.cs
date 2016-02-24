using System;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    public class EvalVisitor2 : RationalBaseVisitor<Tuple<int, int>>
    {
        readonly IMathObjectStack stack;

        public EvalVisitor2(
            IMathObjectStack stack)
        {
            this.stack = stack;
        }

        public int VisitInt(string data)
        {
            int temp;
            int.TryParse(data, out temp);
            return temp;
        }

        public override Tuple<int, int> VisitIntExp(RationalParser.IntExpContext context)
        {
            int item1 = VisitInt(context.INT().GetText());

            var tuple = new Tuple<int, int>(item1, 1);

            var result = new MathObject(tuple);

            stack.Push(result);

            return tuple;
        }

        public override Tuple<int, int> VisitTuple(
            RationalParser.TupleContext context)
        {
            int item1 = VisitInt(context.GetChild(1).GetText());
            int item2 = VisitInt(context.GetChild(3).GetText());

            var tuple = new Tuple<int, int>(item1, item2);

            var result = new MathObject(tuple);

            stack.Push(result);

            return tuple;
        }

        public override Tuple<int, int> VisitParens(
            RationalParser.ParensContext context)
        {
            return Visit(context.expr()); 
        }

        public override Tuple<int, int> VisitAddSub(
            RationalParser.AddSubContext context)
        {
            var left = Visit(context.GetChild(0));
            var right = Visit(context.GetChild(2));

            IMathOperation op = null;

            IMathObject result;

            if (context.op.Type == RationalParser.ADD)
            {
                result = new AddObject(left, right);
                op = new Add();
            }
            else
            {
                result = new AddObject(left, right.GetInverse());
                op = new Add();
            }

            stack.Push(op);

            return result.GetTuple();
        }

        public override Tuple<int, int> VisitMulDiv(
            RationalParser.MulDivContext context)
        {
            var left = Visit(context.GetChild(0));
            var right = Visit(context.GetChild(2));

            IMathOperation op = null;

            IMathObject result;

            if (context.op.Type == RationalParser.MUL)
            {
                result = new MultiplyObject(left, right);
                op = new Multiply();
            }
            else
            {
                result = new MultiplyObject(left, right);
                op = new Multiply();
            }

            stack.Push(op);

            return result.GetTuple();
        }
    }
}

