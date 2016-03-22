using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopFunction : AbstractMathObject, IMathFunction
    {
        IMathObject top;

        IMathObjectStack stack;

        public void Init(IMathFunctionContext context)
        {
            stack = (context as IHasMathObjectStack).Stack;
            top = stack.Top;
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new TopOperation(stack, top);
        }
    }
}

