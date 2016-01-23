using System;

namespace MathObjects.Framework
{
    public interface IMathFunction : IMathObject
    {
        void Init(IMathFunctionContext context);

        IMathObject Perform(IMathFunctionContext context);
    }
}

