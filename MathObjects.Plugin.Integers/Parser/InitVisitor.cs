using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using System.Collections.Generic;

namespace MathObjects.Plugin.Integers
{
    public class InitVisitor : IntegersBaseVisitor<bool>
    {
        readonly IMathObjectStack stack;

        readonly FunctionRegistry registry;

        readonly IDictionary<IntegersParser.FuncCallContext, IMathOperationFactory2> map =
            new Dictionary<IntegersParser.FuncCallContext, IMathOperationFactory2>();

        public InitVisitor(IMathObjectStack stack, FunctionRegistry registry)
        {
            this.stack = stack;
            this.registry = registry;
        }

        public IDictionary<IntegersParser.FuncCallContext, IMathOperationFactory2> Map 
        {
            get { return this.map; }
        }

        public override bool VisitFuncCall(
            IntegersParser.FuncCallContext context)
        {
            if (context.exprList() != null)
            {
                VisitExprList(context.exprList());
            }

            var factoryContext = new FactoryContext();
             
            string name = context.ID().GetText();

            var factory = this.registry.GetFunctionFactory(name);

            if (factory == null)
            {
                return false;
            }

            var f = factory.Create(factoryContext) as IMathOperationFactory2;

            f.Init(new FunctionContext(this.stack));

            map[context] = f;

            return true;
        }
    }
}

