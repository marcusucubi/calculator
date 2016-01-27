using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    public class ConstantObjectFactory : IMathObjectFactory
    {
        readonly double value;

        public ConstantObjectFactory(double value)
        {
            this.value = value;
        }

        public IMathObject Create(IMathObjectFactoryContext context)
        {
            return new ConstantObject(value);
        }
    }
}

