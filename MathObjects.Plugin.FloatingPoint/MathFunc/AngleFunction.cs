using System;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleFunction : AbstractMathObject, IMathFunction
    {
        readonly MathHandler handler;

        readonly string symbol;

        public AngleFunction(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
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
                    var raw = target.GetDouble() / Math.PI;

                    if (Math.Truncate(raw) == raw)
                    {
                        var first = new RadiansOperation();

                        first.SetObjectDecoration("name", "radians");

                        return new CompositeOperation(
                            first, new AngleOperation(this.handler, symbol));
                    }
                    else
                    {
                        var first = new DegreesOperation();

                        first.SetObjectDecoration("name", "degrees");

                        return new CompositeOperation(
                            first, new AngleOperation(this.handler, this.symbol));
                    }
                }
            }
                
            return new AngleOperation(this.handler, this.symbol);
        }

        public class Factory : IMathObjectFactory
        {
            readonly MathHandler handler;

            readonly string symbol;

            public Factory(MathHandler handler, string symbol)
            {
                this.handler = handler;
                this.symbol = symbol;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new AngleFunction(handler, symbol);
            }
        }
    }
}

