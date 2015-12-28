using System;

namespace MathObjects.Framework.Tests
{
    public class TestObjectFactory : IMathObjectFactory
    {
        public IMathObject Create(object parm)
        {
            return new TestMathObject ();
        }
    }
}

