using System;

namespace MathObjects.Framework
{
    public interface IMathValue : IMathObject, ICanBeDefined
    {
        object Value { get; }
    }
}

