using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesFunction : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new DegreesOperation();
        }
    }
}

