using System;

namespace MathObjects.Framework
{
    public interface IMathObjectFactory
    {
        IMathObject Create(object parm);
    }
}

