using System;

namespace MathObjects.Framework
{
    public interface IMathOperation : IMathObject
    {
        IMathObject Perform(IMathObject target);
    }
}

