using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class MathFunction : IMathFunction
    {
        readonly MathHandler handler;

        public MathFunction(MathHandler handler)
        {
            this.handler = handler;
        }

        public void Init(
            IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(
            IMathFunctionContext context)
        {
            return new MathOperation(this.handler);
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
                return new MathFunction(handler);
            }
        }
    }
}

