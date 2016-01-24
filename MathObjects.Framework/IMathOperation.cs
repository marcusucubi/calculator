using System;

namespace MathObjects.Framework
{
    public interface IMathOperation
    {
        IMathObject Perform(IMathObject target);

        int NumberOfParameters { get; }
    }
}

