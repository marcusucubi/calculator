using System;
using Antlr4.Runtime.Tree;
using MathObjects.Framework.Parser;
using MathObjects.Framework;
using System.Diagnostics;
using Antlr4.Runtime;
using System.Collections.Generic;

namespace MathObjects.Plugin.FloatingPoint
{
    public class GenericDefaultProcessor
    {
        readonly IMathObjectStack stack;

        readonly IMathObjectStack stackClone;

        readonly IMathScope scope;

        readonly FunctionRegistry registry;

        public GenericDefaultProcessor(
            IMathObjectStack stack,
            IMathScope scope,
            FunctionRegistry registry)
        {
            this.stack = stack;
            this.stackClone = stack.Clone();
            this.scope = scope;
            this.registry = registry;

            Debug.WriteLine("");
        }

        public IMathObject VisitPrintExpr(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitPrintExpr []");

            var result = visitor.Visit(node.RuleContext.GetChild(0));

            this.stack.Pop();

            result = result.CopyByValue();

            result = this.stack.Push(result);

            Debug.WriteLine("End VisitPrintExpr []");

            return result;
        }

        public IMathObject VisitVariable(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            var name = node.RuleContext.GetChild(0).GetText();

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
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            var left = node.RuleContext.GetChild(0).GetText();

            Debug.WriteLine("Start VisitAssignment [" + left + "]");

            visitor.Visit(node.RuleContext.GetChild(2));

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
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            visitor.Visit(node.RuleContext.GetChild(2));
            visitor.Visit(node.RuleContext.GetChild(0));

            var result = stack.Push(new ExponentOperation());

            Debug.WriteLine("VisitExponent []");

            return result;
        }

        public IMathObject VisitParens(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitParens");

            var result = visitor.Visit(node.RuleContext.GetChild(1));

            Debug.WriteLine("End VisitParens");

            return result; 
        }

        public IMathObject VisitMulDiv(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitMulDiv []");

            var left = visitor.Visit(node.RuleContext.GetChild(2));
            var right = visitor.Visit(node.RuleContext.GetChild(0));

            IMathOperation op = null;

            if (node.RuleContext.GetChild(1).GetText() == "*")
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
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            var list = new List<IMathObject>();

            for(int i = 0; i < node.RuleContext.ChildCount; i++)
            {
                var e = node.RuleContext.GetChild(i);

                var obj = visitor.Visit(e);
                list.Add(obj);
            }

            Debug.WriteLine("VisitExprList []");

            return new ArrayObject(list.ToArray());
        }

        public IMathObject VisitFuncCall(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitFuncCall []");

            var id = node.RuleContext.GetChild(0).GetText();

            var factory = this.registry.GetFunctionFactory(id);

            if (factory == null)
            {
                return new UndefinedObject();
            }

            var factoryContext = new FactoryContext();

            var f = factory.Create(factoryContext) as IMathOperationFactory2;

            f.Init(new OperationFactoryContext(this.stack));

            var functionContext = new OperationFactoryContext(this.stackClone);

            var list = node.RuleContext.GetChild(2) as ParserRuleContext;

            if (list != null)
            {
                VisitExprList(list, visitor);
            }

            var operation = f.Perform(functionContext);

            operation.SetObjectName(id);

            var result = stack.Push(operation);

            result.SetObjectName(id);

            Debug.WriteLine("End VisitFuncCall [" + operation.Symbol + "]");

            return result;
        }

        public IMathObject VisitStackParam(
            IRuleNode node, IParseTreeVisitor<IMathObject> visitor)
        {
            Debug.WriteLine("Start VisitStackParam []");

            string id = node.RuleContext.GetChild(0).GetText();
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

