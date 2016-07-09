using System;
using System.Collections.Generic;

namespace MathObjects.Framework
{
    public class FunctionRegistry : IFunctionRegistry
    {
        readonly IDictionary<string, IMathObjectFactory> map = 
            new Dictionary<string, IMathObjectFactory>();

        public FunctionRegistry()
        {
        }

        public void Put(string name, IMathObjectFactory factory)
        {
            map[name] = factory;
        }

        public IMathObjectFactory GetFunctionFactory(string name)
        {
            if (!map.ContainsKey(name))
            {
                return null;
            }

            return map[name];
        }
    }
}

