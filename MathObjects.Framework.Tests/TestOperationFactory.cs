using System;

namespace MathObjects.Framework.Tests
{
    public class TestOperationFactory : IMathOperationFactory
    {
        public IMathOperation Create(object parm)
        {
            return new TestMathOperation ();
        }
    }
}

