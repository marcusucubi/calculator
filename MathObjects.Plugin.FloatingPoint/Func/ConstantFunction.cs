using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantFunction : AbstractMathObject, IMathOperationFactory2
    {
        readonly double value;

        public ConstantFunction(double value)
        {
            this.value = value;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new ConstantOperation(this.value);
        }

        public class Factory : IMathObjectFactory
        {
            readonly double value;

            public Factory(double value)
            {
                this.value = value;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new ConstantFunction(this.value);
            }
        }
    }
}

