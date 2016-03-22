using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class MathFunction : AbstractMathObject, IMathFunction
    {
        readonly MathHandler handler;

        readonly string symbol;

        public MathFunction(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(
            IMathFunctionContext context)
        {
            return new MathOperation(this.handler, this.symbol);
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
                return new MathFunction(handler, this.symbol);
            }
        }
    }
}

