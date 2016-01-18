using System;

namespace MathObjects.Framework
{
    public interface IMathOperationFactory
    {
        IMathOperation Create(object parm);
    }
}

