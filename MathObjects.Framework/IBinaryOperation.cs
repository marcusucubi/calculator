using System;

namespace MathObjects.Framework
{
    public interface IBinaryOperation
    {
        IMathObject Perform(IMathObject left, IMathObject right);
    }
}

