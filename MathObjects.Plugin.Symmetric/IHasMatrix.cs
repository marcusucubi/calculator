using System;
using MathObjects.Core.Matrix;

namespace MathObjects.Plugin.Symmetric
{
    public interface IHasMatrix
    {
        IntegerMatrix Matrix { get; }
    }
}

