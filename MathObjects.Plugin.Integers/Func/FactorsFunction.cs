using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers.Func
{
    public class FactorsFunction : IMathFunction
    {
        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new FactorsOperation();
        }
    }
}

