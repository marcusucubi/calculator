using System;

namespace MathObjects.Core.Matrix
{
    public interface IHasOperation<T>
    {
        T MultipyBy(T other);

        T Add(T other);
    }
}
