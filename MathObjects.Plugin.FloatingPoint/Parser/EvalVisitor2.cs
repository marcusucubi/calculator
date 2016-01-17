using System;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor2 : FloatingPointBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        readonly FactoryRegistry registry;

        public EvalVisitor2(FactoryRegistry registry, IMathObjectStack stack)
        {
            this.registry = registry;
            this.stack = stack;
        }

        public override IMathObject VisitInt(FloatingPointParser.IntContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Enter(result);
            return result;
        }

        public override IMathObject VisitValue(FloatingPointParser.ValueContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Enter(result);
            return result;
        }

        public override IMathObject VisitParens(FloatingPointParser.ParensContext context)
        {
            return Visit(context.expr()); 
        }

        public override IMathObject VisitAddSub(FloatingPointParser.AddSubContext context)
        {
            var left = Visit(context.GetChild(0));
            var right = Visit(context.GetChild(2));

            IBinaryOperation op = null;

            IMathObject result;

            if (context.op.Type == FloatingPointParser.ADD)
            {
                result = new AddObject(left.GetDouble(), right.GetDouble());
                op = registry.BinaryOperationDictionary[FactoryRegistry.ADD].Create(null);
            }
            else
            {
                result = new AddObject(left.GetDouble(), -right.GetDouble());
                op = registry.BinaryOperationDictionary[FactoryRegistry.SUBTRACT].Create(null);
            }

            stack.Perform(op);

            return result;
        }

        public override IMathObject VisitMulDiv(FloatingPointParser.MulDivContext context)
        {
            var left = Visit(context.GetChild(0));
            var right = Visit(context.GetChild(2));

            IBinaryOperation op = null;

            IMathObject result;

            if (context.op.Type == FloatingPointParser.MUL)
            {
                result = new MultiplyObject(left.GetDouble(), right.GetDouble());
                op = registry.BinaryOperationDictionary[FactoryRegistry.MULTIPLY].Create(null);
            }
            else
            {
                result = new MultiplyObject(left.GetDouble(), 1 / right.GetDouble());
                op = registry.BinaryOperationDictionary[FactoryRegistry.DIVIDE].Create(null);
            }

            stack.Perform(op);

            return result;
        }
    }
}

