using System;
using System.Diagnostics;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    public class EvalProcessor1 
    {
        readonly AbstractParseTreeVisitor<IMathObject> visitor;

        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        readonly InitVisitor init;

        public EvalProcessor1(
            AbstractParseTreeVisitor<IMathObject> visitor,
            IMathObjectStack stack,
            IMathScope scope,
            InitVisitor init)
        {
            this.visitor = visitor;
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
            this.init = init;
        }

        public IMathObject VisitPrintExpr(
            ParserRuleContext context)
        {
            Debug.WriteLine("Start VisitPrintExpr []");

            var result = visitor.Visit(context.GetChild(0));

            this.stack.Pop();

            result = result.CopyByValue();

            result = this.stack.Push(result);

            Debug.WriteLine("End VisitPrintExpr []");

            return result;
        }

        public IMathObject VisitVariable(
            ParserRuleContext context)
        {
            var name = context.GetChild(0).GetText();

            Debug.WriteLine("Start VisitVariable [" + name + "]");

            var value = new Ref(this.scope, name);

            var result = stack.Push(value);

            value.SetObjectName(name);
            result.SetObjectName(name);

            Debug.WriteLine("End VisitVariable [" + 
                name + "=" + value.GetDouble() + "]");

            return result;
        }

        public IMathObject VisitAssignment(
            ParserRuleContext context)
        {
            var left = context.GetChild(0).GetText();

            Debug.WriteLine("Start VisitAssignment [" + left + "]");

            visitor.Visit(context.GetChild(2));

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

        public IMathObject VisitExponent(
            ParserRuleContext context)
        {
            visitor.Visit(context.GetChild(2));
            visitor.Visit(context.GetChild(0));

            var result = stack.Push(new ExponentOperation());

            Debug.WriteLine("VisitExponent []");

            return result;
        }

        public IMathObject VisitParens(
            ParserRuleContext context)
        {
            Debug.WriteLine("Start VisitParens");

            var result = visitor.Visit(context.GetChild(1));

            Debug.WriteLine("End VisitParens");

            return result; 
        }

        public IMathObject VisitMulDiv(
            ParserRuleContext context)
        {
            Debug.WriteLine("Start VisitMulDiv []");

            var left = visitor.Visit(context.GetChild(2));
            var right = visitor.Visit(context.GetChild(0));

            IMathOperation op = null;

            if (context.GetChild(1).GetText() == "*")
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

        public IMathObject VisitExprList(
            ParserRuleContext context)
        {
            var list = new List<IMathObject>();

            foreach (var e in context.children)
            {
                var obj = visitor.Visit(e);
                list.Add(obj);
            }

            Debug.WriteLine("VisitExprList []");

            return new ArrayObject(list.ToArray());
        }

        public IMathObject VisitFuncCall(
            ParserRuleContext context)
        {
            Debug.WriteLine("Start VisitFuncCall []");

            var id = context.GetChild(0).GetText();

            if (!this.init.Map.ContainsKey(context))
            {
                var error = new UndefinedObject();

                stack.Push(error);

                Debug.WriteLine("End VisitFuncCall [" + id + "]");

                return error;
            }

            var f = this.init.Map[context];

            var functionContext = new OperationFactoryContext(this.stackClone);

            var list = context.GetChild(2) as ParserRuleContext;

            if (list != null)
            {
                VisitExprList(list);
            }

            var operation = f.Perform(functionContext);

            operation.SetObjectName(id);

            var result = stack.Push(operation);

            result.SetObjectName(id);

            Debug.WriteLine("End VisitFuncCall [" + operation.Symbol + "]");

            return result;
        }

        public IMathObject VisitStackParam(
            ParserRuleContext context)
        {
            Debug.WriteLine("Start VisitStackParam []");

            string id = context.GetChild(0).GetText();
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

