using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopFunction : IMathFunction
    {
        IMathObject top;

        public void Init(IMathFunctionContext context)
        {
            top = (context as IHasMathObjectStack).Stack.Top;
        }

        public IMathObject Perform(IMathFunctionContext context)
        {
            return top;
        }
    }
}

