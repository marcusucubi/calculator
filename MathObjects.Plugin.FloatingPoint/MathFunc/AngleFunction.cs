using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleFunction : IMathFunction
    {
        readonly MathHandler handler;

        public AngleFunction(MathHandler handler)
        {
            this.handler = handler;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            // Convert to degrees if needed
            var stack = (context as IHasMathObjectStack).Stack;
            if (stack.Size > 0)
            {
                var target = stack.Top;

                var angle = target.GetValue<AngleObject>();

                if (angle == null)
                {
                    var first = new DegreesOperation();

                    first.SetObjectDecoration("name", "degrees");

                    return new CompositeOperation(
                        first, new AngleOperation(this.handler));
                }
            }
                
            return new AngleOperation(this.handler);
        }

        public class Factory : IMathObjectFactory
        {
            readonly MathHandler handler;

            public Factory(MathHandler handler)
            {
                this.handler = handler;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new AngleFunction(handler);
            }
        }
    }
}

