using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor2 : FloatingPointBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        readonly FactoryRegistry registry;

        readonly InitVisitor init;

        readonly IMathObject top;

        public EvalVisitor2(
            FactoryRegistry registry, 
            IMathObjectStack stack,
            InitVisitor init)
        {
            this.registry = registry;
            this.stack = stack;
            this.init = init;
            this.top = stack.Top;
        }

        public override IMathObject VisitTOP(
            FloatingPointParser.TOPContext context)
        {
            stack.Push(this.top);
            return this.top;
        }

        public override IMathObject VisitPI(
            FloatingPointParser.PIContext context)
        {
            var result = new MathObject(Math.PI);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitNegative(
            FloatingPointParser.NegativeContext context)
        {
            Visit(context.expr());

            stack.Push(new Negative());

            return new NegativeObject(this.stack.Top.GetDouble());
        }

        public override IMathObject VisitExponent(
            FloatingPointParser.ExponentContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            stack.Push(new ExponentOperation());

            return new ExponentObject(left.GetDouble(), right.GetDouble());
        }

        public override IMathObject VisitExprList(
            FloatingPointParser.ExprListContext context)
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
            FloatingPointParser.FuncCallContext context)
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

            var desc = operation as DecoratableObject;
            if (desc != null)
            {
                desc.ReadAttributes();
            }

            var canDecorate = operation as ICanDecorate;
            if (canDecorate != null)
            {
                canDecorate.DecorationMap[typeof(IHasName)] = 
                    context.ID().GetText();
            }

            if (stack.Size < operation.NumberOfParameters)
            {
                var error = new ErrorObject("not enough parameters");
                stack.Push(error);
                return error;
            }

            var paramList = stack.Peek(operation.NumberOfParameters);

            stack.Push(operation);

            return operation.Perform(paramList.ToArray());
        }

        public override IMathObject VisitFloat(
            FloatingPointParser.FloatContext context)
        {
            double temp;
            double.TryParse(context.FLOAT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitInt(
            FloatingPointParser.IntContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitValue(
            FloatingPointParser.ValueContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);
            return result;
        }

        public override IMathObject VisitParens(
            FloatingPointParser.ParensContext context)
        {
            return Visit(context.expr()); 
        }

        public override IMathObject VisitAddSub(
            FloatingPointParser.AddSubContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            IMathOperation op = null;

            IMathObject result;

            if (context.op.Type == FloatingPointParser.ADD)
            {
                result = new AddObject(left.GetDouble(), right.GetDouble());
                op = new Add();
            }
            else
            {
                result = new SubtractObject(left.GetDouble(), -right.GetDouble());
                op = new Subtract();
            }

            stack.Push(op);

            return result;
        }

        public override IMathObject VisitMulDiv(
            FloatingPointParser.MulDivContext context)
        {
            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            IMathOperation op = null;

            IMathObject result;

            if (context.op.Type == FloatingPointParser.MUL)
            {
                result = new MultiplyObject(left.GetDouble(), right.GetDouble());
                op = registry.OperationDictionary[FactoryRegistry.MULTIPLY].Create(null);
            }
            else
            {
                result = new MultiplyObject(left.GetDouble(), 1 / right.GetDouble());
                op = registry.OperationDictionary[FactoryRegistry.DIVIDE].Create(null);
            }

            stack.Push(op);

            return result;
        }
    }
}

