using System;

namespace MathObjects.Framework
{
    public interface IMathOperationFactory
    {
        IMathBinaryOperation Create(object parm);
    }
}

