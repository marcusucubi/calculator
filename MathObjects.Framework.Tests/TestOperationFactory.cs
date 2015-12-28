using System;

namespace MathObjects.Framework.Tests
{
    public class TestOperationFactory : IMathOperationFactory
    {
        public IBinaryOperation Create(object parm)
        {
            return new TestMathOperation ();
        }
    }
}

