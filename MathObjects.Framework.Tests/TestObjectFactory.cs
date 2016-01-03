using System;

namespace MathObjects.Framework.Tests
{
    public class TestObjectFactory : IMathObjectFactory
    {
        public IMathObject Create(string parm)
        {
            return new TestMathObject ();
        }
    }
}

