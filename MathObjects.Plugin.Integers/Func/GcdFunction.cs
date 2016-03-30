using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers.Func
{
    class GcdFunction : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(IMathOperationFactoryContext context)
        {
            return new GcdOperation();
        }
    }
}

