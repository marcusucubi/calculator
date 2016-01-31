using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestBinaryOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            return new TestObject(
                objs[0].GetValue<string>() + " " + objs[1].GetValue<string>()
            );
        }
    }
}

