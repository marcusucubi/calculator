using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleOperationFactory : AbstractMathObject, IMathOperationFactory2
    {
        readonly MathHandler handler;

        readonly string symbol;

        public InverseAngleOperationFactory(MathHandler handler, string symbol)
        {
            this.handler = handler;
            this.symbol = symbol;
        }

        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(IMathOperationFactoryContext context)
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
                return new InverseAngleOperationFactory(handler, symbol);
            }
        }
    }
}

