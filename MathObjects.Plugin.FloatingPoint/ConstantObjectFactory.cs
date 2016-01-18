using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ConstantObjectFactory : IMathObjectFactory
    {
        readonly double value;

        public ConstantObjectFactory(double value)
        {
            this.value = value;
        }

        public IMathObject Create(object parm)
        {
            return new ConstantObject(value);
        }
    }
}

