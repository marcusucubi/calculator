using System;

namespace MathObjects.Framework.Tests
{
    public class TestOperationFactory : IMathBinaryOperationFactory
    {
        public IMathBinaryOperation Create(object parm)
        {
            return new TestMathOperation ();
        }
    }
}

