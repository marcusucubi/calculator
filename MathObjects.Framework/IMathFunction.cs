using System;

namespace MathObjects.Framework
{
    public interface IMathFunction : IMathObject
    {
        void Init(IMathFunctionContext context);

        IMathOperation Perform(IMathFunctionContext context);
    }
}

