using System;

namespace MathObjects.Framework
{
    public interface IMathOperationFactory2 : IMathObject
    {
        void Init(IMathFunctionContext context);

        IMathOperation Perform(IMathFunctionContext context);
    }
}

