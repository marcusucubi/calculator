using System;

namespace MathObjects.Framework
{
    public interface IFunctionRegistry
    {
        void Put(string name, IMathObjectFactory factory);

        IMathObjectFactory GetFunctionFactory(string name);
    }
}

