﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalVisitor2 : FloatingPointBaseVisitor<IMathObject>
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        readonly InitVisitor init;

        public EvalVisitor2(
            IMathObjectStack stack,
            IMathScope scope,
            InitVisitor init)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
            this.init = init;

            Debug.WriteLine("");
        }

        public override IMathObject VisitPrintExpr(
            FloatingPointParser.PrintExprContext context)
        {
            Debug.WriteLine("Start VisitPrintExpr []");

            var result = Visit(context.expr());

            this.stack.Pop();

            result = result.CopyByValue();

            result = this.stack.Push(result);

            Debug.WriteLine("End VisitPrintExpr []");

            return result;
        }

        public override IMathObject VisitVariable(
            FloatingPointParser.VariableContext context)
        {
            var name = context.ID().GetText();

            Debug.WriteLine("Start VisitVariable [" + name + "]");

            var value = new Ref(this.scope, name);

            var result = stack.Push(value);

            value.SetObjectName(name);
            result.SetObjectName(name);

            Debug.WriteLine("End VisitVariable [" + 
                name + "=" + value.GetDouble() + "]");

            return result;
        }

        public override IMathObject VisitAssignment(
            FloatingPointParser.AssignmentContext context)
        {
            var left = context.ID().GetText();

            Debug.WriteLine("Start VisitAssignment [" + left + "]");

            Visit(context.expr());

            var value = this.stack.Peek();

            this.scope.Put(left, value);

            stack.Pop();

            var refer = new ValueRef(this.scope, left);

            var result = stack.Push(refer);

            result.SetObjectName(left);

            Debug.WriteLine("End VisitAssignment [" + 
                left + "=" + value + "] ["+ 
                left + "=" + value.GetDouble() + "]");

            return result;
        }

        public override IMathObject VisitNegative(
            FloatingPointParser.NegativeContext context)
        {
            Visit(context.expr());

            var result = stack.Push(new Negative());

            Debug.WriteLine("VisitNegative");

            return result;
        }

        public override IMathObject VisitExponent(
            FloatingPointParser.ExponentContext context)
        {
            Visit(context.GetChild(2));
            Visit(context.GetChild(0));

            var result = stack.Push(new ExponentOperation());

            Debug.WriteLine("VisitExponent []");

            return result;
        }

        public override IMathObject VisitFloat(
            FloatingPointParser.FloatContext context)
        {
            double temp;
            double.TryParse(context.FLOAT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);

            Debug.WriteLine("VisitFloat [" + result + "]");

            return result;
        }

        public override IMathObject VisitInt(
            FloatingPointParser.IntContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);

            Debug.WriteLine("VisitInt [" + result + "]");

            return result;
        }

        public override IMathObject VisitValue(
            FloatingPointParser.ValueContext context)
        {
            double temp;
            double.TryParse(context.INT().GetText(), out temp);
            var result = new MathObject(temp);
            stack.Push(result);

            Debug.WriteLine("VisitValue [" + result + "]");

            return result;
        }

        public override IMathObject VisitParens(
            FloatingPointParser.ParensContext context)
        {
            Debug.WriteLine("Start VisitParens");

            var result = Visit(context.expr());
            
            Debug.WriteLine("End VisitParens");

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

            var result = stack.Push(op);

            Debug.WriteLine("End VisitAddSub [" + 
                left + "+" + right + "] [" + result.GetDouble() + "]");

            return result;
        }

        public override IMathObject VisitMulDiv(
            FloatingPointParser.MulDivContext context)
        {
            Debug.WriteLine("Start VisitMulDiv []");

            var left = Visit(context.GetChild(2));
            var right = Visit(context.GetChild(0));

            IMathOperation op = null;

            if (context.op.Type == FloatingPointParser.MUL)
            {
                op = new Multiply();
            }
            else
            {
                op = new Divide();
            }

            var result = stack.Push(op);

            Debug.WriteLine("End VisitMulDiv [" + 
                left + "+" + right + "] [" + result.GetDouble() + "]");

            return result;
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

            Debug.WriteLine("VisitExprList []");

            return new ArrayObject(list.ToArray());
        }

        public override IMathObject VisitFuncCall(
            FloatingPointParser.FuncCallContext context)
        {
            Debug.WriteLine("Start VisitFuncCall []");

            var id = context.ID().GetText();

            if (!this.init.Map.ContainsKey(context))
            {
                var error = new UndefinedObject();

                stack.Push(error);

                Debug.WriteLine("End VisitFuncCall [" + id + "]");

                return error;
            }

            var f = this.init.Map[context];

            var functionContext = new OperationFactoryContext(this.stackClone);

            if (context.exprList() != null)
            {
                VisitExprList(context.exprList());
            }

            var operation = f.Perform(functionContext);

            operation.SetObjectName(id);

            var result = stack.Push(operation);

            result.SetObjectName(id);

            Debug.WriteLine("End VisitFuncCall [" + operation.Symbol + "]");

            return result;
        }

        public override IMathObject VisitStackParam(
            FloatingPointParser.StackParamContext context)
        {
            Debug.WriteLine("Start VisitStackParam []");

            string id = context.STACK_PARAM().GetText();
            string s = id.Trim('%');

            int temp;
            int.TryParse(s, out temp);

            var a = stackClone.ToArray();

            IMathObject obj = new UndefinedObject();
            if (temp < a.Length)
            {
                obj = new StackParamObject(a[temp]);
            }

            var operation = new StackParamOperation(obj);

            operation.SetObjectName(id);

            var result = stack.Push(operation);

            result.SetObjectName(id);

            Debug.WriteLine("End VisitStackParam [" + result + "]");
            
            return result;
        }
    }
}

