using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class MathOperationFactory : AbstractMathObject, IMathOperationFactory2
    {
        readonly MathHandler handler;

        readonly string symbol;

        public MathOperationFactory(MathHandler handler, string symbol)
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
                return new MathOperationFactory(handler, this.symbol);
            }
        }
    }
}

