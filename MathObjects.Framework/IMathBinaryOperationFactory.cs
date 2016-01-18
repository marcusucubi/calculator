using System;

namespace MathObjects.Framework
{
    public interface IMathBinaryOperationFactory
    {
        IMathBinaryOperation Create(object parm);
    }
}

