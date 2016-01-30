using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class InverseAngleFunction : IMathFunction
    {
        readonly MathHandler handler;

        public InverseAngleFunction(MathHandler handler)
        {
            this.handler = handler;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new InverseAngleOperation(this.handler);
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
                return new InverseAngleFunction(handler);
            }
        }
    }
}

