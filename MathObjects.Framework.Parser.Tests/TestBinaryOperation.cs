using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestBinaryOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "test"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            return new TestObject(
                objs[0].GetValue<string>() + " " + objs[1].GetValue<string>()
            );
        }
    }
}

