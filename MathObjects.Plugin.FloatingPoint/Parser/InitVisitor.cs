﻿using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using System.Collections.Generic;

namespace MathObjects.Plugin.FloatingPoint
{
    public class InitVisitor : FloatingPointBaseVisitor<bool>
    {
        readonly IMathObjectStack stack;

        readonly FunctionRegistry registry;

        readonly IDictionary<FloatingPointParser.FuncCallContext, IMathOperationFactory2> map =
            new Dictionary<FloatingPointParser.FuncCallContext, IMathOperationFactory2>();

        public InitVisitor(
            FunctionRegistry registry, 
            IMathObjectStack stack)
        {
            this.registry = registry;
            this.stack = stack;
        }

        public IDictionary<FloatingPointParser.FuncCallContext, IMathOperationFactory2> Map 
        {
            get { return this.map; }
        }

        public override bool VisitFuncCall(
            FloatingPointParser.FuncCallContext context)
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

