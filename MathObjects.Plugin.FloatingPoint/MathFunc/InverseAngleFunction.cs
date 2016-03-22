using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleFunction : AbstractMathObject, IMathFunction
    {
        readonly MathHandler handler;

        readonly string symbol;

        public InverseAngleFunction(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new InverseAngleOperation(this.handler, this.symbol);
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
                return new InverseAngleFunction(handler, symbol);
            }
        }
    }
}

