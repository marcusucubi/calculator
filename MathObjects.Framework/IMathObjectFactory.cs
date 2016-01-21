using System;

namespace MathObjects.Framework
{
    public interface IMathObjectFactory
    {
        IMathObject Create(IMathObjectFactoryContext context);
    }
}

