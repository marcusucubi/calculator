using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansFunction : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new RadiansOperation();
        }
    }
}

