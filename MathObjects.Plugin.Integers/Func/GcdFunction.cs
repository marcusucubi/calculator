using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers.Func
{
    class GcdFunction : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new GcdOperation();
        }
    }
}

