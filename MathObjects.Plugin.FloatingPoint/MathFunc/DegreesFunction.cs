using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesFunction : AbstractMathObject, IMathFunction
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

