using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantFunction : IMathFunction
    {
        readonly double value;

        readonly string name;

        public ConstantFunction(double value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public IMathOperation Perform(IMathFunctionContext context)
        {
            return new ConstantOperation(this.value, this.name);
        }

        public class Factory : IMathObjectFactory
        {
            readonly double value;

            readonly string name;

            public Factory(double value, string name)
            {
                this.value = value;
                this.name = name;
            }

            public IMathObject Create(IMathObjectFactoryContext context)
            {
                return new ConstantFunction(this.value, this.name);
            }
        }
    }
}

