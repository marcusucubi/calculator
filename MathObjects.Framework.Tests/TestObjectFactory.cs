using System;

namespace MathObjects.Framework.Tests
{
    public class TestObjectFactory : IMathObjectFactory
    {
        public IMathObject Create(IMathObjectFactoryContext context)
        {
            return new TestMathObject ();
        }
    }
}

