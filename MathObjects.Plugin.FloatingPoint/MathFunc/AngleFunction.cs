using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleFunction : IMathFunction
    {
        readonly MathHandler handler;

        readonly string name;

        public AngleFunction(MathHandler handler, string name)
        {
            this.handler = handler;
            this.name = name;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new AngleOperation(this.handler, name);
        }

        public class Factory : IMathObjectFactory
        {
            readonly MathHandler handler;

            readonly string name;

            public Factory(MathHandler handler, string name)
            {
                this.handler = handler;
                this.name = name;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new AngleFunction(handler, name);
            }
        }
    }
}

