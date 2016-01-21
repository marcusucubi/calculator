using System;

namespace MathObjects.Framework
{
    public interface IMathFunction : IMathObject
    {
        void Perform(IMathFunctionContext context);
    }
}

