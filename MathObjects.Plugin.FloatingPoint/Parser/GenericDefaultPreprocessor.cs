using System;
using System.Collections.Generic;
using MathObjects.Framework;
using Antlr4.Runtime;
using MathObjects.Framework.Parser;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    public class GenericDefaultPreprocessor
    {
        readonly IMathObjectStack stack;

        readonly FunctionRegistry registry;

        readonly IDictionary<RuleContext, IMathOperationFactory2> map2 =
            new Dictionary<RuleContext, IMathOperationFactory2>();

        public GenericDefaultPreprocessor(
            FunctionRegistry registry, 
            IMathObjectStack stack)
        {
            this.registry = registry;
            this.stack = stack;
        }

        public IDictionary<RuleContext, IMathOperationFactory2> Map2 
        {
            get { return this.map2; }
        }

        public bool VisitFuncCall(
            IRuleNode node)
        {
            var factoryContext = new FactoryContext();

            var name = node.RuleContext.GetChild(0).GetText();

            var factory = this.registry.GetFunctionFactory(name);

            if (factory == null)
            {
                return false;
            }

            var f = factory.Create(factoryContext) as IMathOperationFactory2;

            f.Init(new OperationFactoryContext(this.stack));

            //map2[node] = f;

            return true;
        }
    }
}

