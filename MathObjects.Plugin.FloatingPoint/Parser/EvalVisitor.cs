using System;
using System.Collections.Generic;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor : FloatingPointBaseVisitor<double>
    {
        //Dictionary<String, int> memory = new Dictionary<String, int>();

        public EvalVisitor()
        {
        }

        public override double VisitInt(FloatingPointParser.IntContext context)
        {
            int temp;
            int.TryParse(context.INT().GetText(), out temp);
            return temp;
        }

        public override double VisitValue(FloatingPointParser.ValueContext context)
        {
            int temp;
            int.TryParse(context.INT().GetText(), out temp);
            return temp;
        }

        public override double VisitParens(FloatingPointParser.ParensContext context)
        {
            return Visit(context.expr()); 
        }

        public override double VisitAddSub(FloatingPointParser.AddSubContext context)
        {
            double left = Visit(context.GetChild(0));
            double right = Visit(context.GetChild(2));

            if (context.op.Type == FloatingPointParser.ADD)
            {
                return left + right;
            }

            return left - right;
        }

        public override double VisitMulDiv(FloatingPointParser.MulDivContext context)
        {
            double left = Visit(context.GetChild(0));
            double right = Visit(context.GetChild(2));

            if (context.op.Type == FloatingPointParser.MUL)
            {
                return left * right;
            }

            return left / right;
        }
    }
}

