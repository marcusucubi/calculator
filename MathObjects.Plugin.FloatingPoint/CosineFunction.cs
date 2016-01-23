using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class CosineFunction : IMathFunction
    {
        public void Init(
            IMathFunctionContext context)
        {
        }

        public IMathObject Perform(
            IMathFunctionContext context)
        {
            return new CosineOperation();
        }
    }
}

