using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers
{
    public class EvalVisitor2 : IntegersBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        readonly InitVisitor init;

        readonly IMathObject top;

        public EvalVisitor2(
            FactoryRegistry registry, 
            IMathObjectStack stack,
            InitVisitor init)
        {
            this.stack = stack;
            this.init = init;
            this.top = stack.Top;
        }

        public override IMathObject VisitNegative(
            IntegersParser.NegativeContext context)
        {
            Visit(context.expr());

            stack.Push(new Negative());

            return new NegativeObject(this.stack.Top.GetInteger());
        }

        public override IMathObject VisitExponent(
            IntegersParser.ExponentContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            stack.Push(new ExponentOperation());

            return new ExponentObject(left.GetInteger(), right.GetInteger());
        }

        public override IMathObject VisitExprList(
            IntegersParser.ExprListContext context)
        {
            var list = new List<IMathObject>();

            foreach (var e in context.expr())
            {
                var obj = Visit(e);
                list.Add(obj);
            }

            return new ArrayObject(list.ToArray());
        }

        public override IMathObject VisitFuncCall(
            IntegersParser.FuncCallContext context)
        {
            if (!this.init.Map.ContainsKey(context))
            {
                var error = new ErrorObject("function not found: " + context.ID().GetText());
                stack.Push(error);
                return error;
            }
            
            var f = this.init.Map[context];

            var functionContext = new FunctionContext(this.stack);

            if (context.exprList() != null)
            {
                VisitExprList(context.exprList());
            }

            var operation = f.Perform(functionContext);

            stack.Push(operation);
            
            var result = operation.Perform(stack.Top);

            return result;
        }

        public override IMathObject VisitInt(
            IntegersParser.IntContext context)
        {
            int temp;
            int.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitValue(
            IntegersParser.ValueContext context)
        {
            int temp;
            int.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitParens(
            IntegersParser.ParensContext context)
        {
            return Visit(context.expr()); 
        }

        public override IMathObject VisitAdd(IntegersParser.AddContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            stack.Push(new Add());

            return new AddObject(left.GetInteger(), right.GetInteger());
        }

        public override IMathObject VisitSub(IntegersParser.SubContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            stack.Push(new Subtract());

            return new SubtractObject(left.GetInteger(), right.GetInteger());
        }

        public override IMathObject VisitMulDiv(
            IntegersParser.MulDivContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            IMathBinaryOperation op = null;

            IMathObject result;

            result = new MultiplyObject(left.GetInteger(), right.GetInteger());
            op = new Multiply();

            stack.Push(op);

            return result;
        }
    }
}

