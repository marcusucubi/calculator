using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopFunction : FunctionObject
    {
        protected override IMathObject InternalGetResult(IMathFunctionContext context)
        {
            var stack = (context as IHasMathObjectStack).Stack;

            return stack.Top;
        }
    }
}

