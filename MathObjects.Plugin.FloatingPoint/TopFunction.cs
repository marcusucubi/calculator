using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopFunction : FunctionObject
    {
        IMathObject top;

        public override void Init(IMathFunctionContext context)
        {
            top = (context as IHasMathObjectStack).Stack.Top;
        }

        protected override IMathObject InternalGetResult(IMathFunctionContext context)
        {
            return top;
        }
    }
}

