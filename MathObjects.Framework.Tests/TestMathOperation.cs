using System;

namespace MathObjects.Framework.Tests
{
    public class TestMathOperation : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            return new TestMathObject ();
        }
    }
}

