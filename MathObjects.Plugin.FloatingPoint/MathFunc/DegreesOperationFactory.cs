using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesOperationFactory : 
        AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(IMathOperationFactoryContext context)
        {
            return new DegreesOperation();
        }
    }
}

