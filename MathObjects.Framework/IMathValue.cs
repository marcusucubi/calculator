using System;

namespace MathObjects.Framework
{
    public interface IMathValue : IMathObject
    {
        object Value { get; }
    }
}

