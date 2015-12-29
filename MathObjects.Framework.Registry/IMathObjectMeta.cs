using System;

namespace MathObjects.Framework.Registry
{
    public interface IMathObjectMeta
    {
        object[] PossibleParameters { get; }
    }
}

