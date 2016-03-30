using System;

namespace MathObjects.Framework
{
    public interface IMathOperationFactory2 : IMathObject
    {
        void Init(IMathOperationFactoryContext context);

        IMathOperation Perform(IMathOperationFactoryContext context);
    }
}

