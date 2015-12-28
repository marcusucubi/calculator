using System;

namespace MathObjects.Framework
{
    public interface IMathOperationFactory
    {
        IBinaryOperation Create(object parm);
    }
}

