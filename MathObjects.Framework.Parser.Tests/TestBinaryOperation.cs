using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestBinaryOperation : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            return new TestObject(
                left.GetValue<string>() + " " + right.GetValue<string>()
            );
        }
    }
}

