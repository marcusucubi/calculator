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

        readonly FactoryRegistry registry;

        readonly IDictionary<IntegersParser.FuncCallContext, IMathFunction> map =
            new Dictionary<IntegersParser.FuncCallContext, IMathFunction>();

        public InitVisitor(
            FactoryRegistry registry, 
            IMathObjectStack stack)
        {
            this.registry = registry;
            this.stack = stack;
        }

        public IDictionary<IntegersParser.FuncCallContext, IMathFunction> Map 
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

            var f = factory.Create(factoryContext) as IMathFunction;

            f.Init(new FunctionContext(this.stack));

            map[context] = f;

            return true;
        }
    }
}

