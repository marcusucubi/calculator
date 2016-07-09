using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint2
{
    public class FunctionRegistry : IFunctionRegistry
    {
        public void Put(string name, IMathObjectFactory factory)
        {
        }

        public IMathObjectFactory GetFunctionFactory(string name)
        {
            return new Factory(name, name);
        }

        public class Factory : IMathObjectFactory
        {
            readonly string name;

            readonly string symbol;

            public Factory(string name, string symbol)
            {
                this.name = name;
                this.symbol = symbol;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new MathOperationFactory(2, symbol, name);
            }
        }
    }
}

