using System;
using MathObjects.Core.Matrix;

namespace MathObjects.Framework
{
    public interface IHasMatrix
    {
        IntegerMatrix Matrix { get; }
    }
}

