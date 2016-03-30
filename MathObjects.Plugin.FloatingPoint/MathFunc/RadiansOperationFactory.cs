using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansOperationFactory : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(IMathOperationFactoryContext context)
        {
            return new RadiansOperation();
        }
    }
}

