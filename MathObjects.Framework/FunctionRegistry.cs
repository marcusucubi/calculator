using System;
using System.Collections.Generic;

namespace MathObjects.Framework
{
    public class FunctionRegistry
    {
        readonly IDictionary<string, IMathObjectFactory> map = 
            new Dictionary<string, IMathObjectFactory>();

        public void Put(string name, IMathObjectFactory factory)
        {
            map[name] = factory;
        }

        public IMathObjectFactory GetFunctionFactory(string name)
        {
            return map[name];
        }
    }
}

