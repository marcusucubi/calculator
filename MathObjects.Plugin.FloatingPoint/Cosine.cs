using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class CosineFunction : FunctionObject
    {
        public override void Init(IMathFunctionContext context)
        {
        }

        protected override IMathObject InternalGetResult(IMathFunctionContext context)
        {
            var stack = (context as IHasMathObjectStack).Stack;

            if (stack.Top == null)
            {
                return new ErrorObject();
            }

            var param = stack.Pop();

            var value = param.GetDouble();

            return new ConstantObject(Math.Cos(value));
        }
    }
}

