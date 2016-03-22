using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers.Func
{
    public class FactorsFunction : AbstractMathObject, IMathFunction
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

