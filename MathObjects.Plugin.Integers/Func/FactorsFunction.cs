using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers.Func
{
    public class FactorsFunction : AbstractMathObject, IMathOperationFactory2
    {
        public void Init(IMathOperationFactoryContext context)
        {
        }

        public IMathOperation Perform(IMathOperationFactoryContext context)
        {
            return new FactorsOperation();
        }
    }
}

