using System;

namespace MathObjects.Framework
{
    public interface IMathFunction : IMathObject
    {
        void Init(IMathFunctionContext context);

        void Perform(IMathFunctionContext context);
    }
}

