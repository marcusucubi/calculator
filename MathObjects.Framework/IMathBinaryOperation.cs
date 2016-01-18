using System;

namespace MathObjects.Framework
{
    public interface IMathBinaryOperation
    {
        IMathObject Perform(IMathObject left, IMathObject right);
    }
}

