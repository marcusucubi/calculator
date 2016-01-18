using System;

namespace MathObjects.Framework.Tests
{
    public class TestOperationFactory : IMathOperationFactory
    {
        public IMathBinaryOperation Create(object parm)
        {
            return new TestMathOperation ();
        }
    }
}

