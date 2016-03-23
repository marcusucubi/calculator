using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestUniraryOperation : AbstractMathOperation 
    {
        public override IMathObject Perform(IMathObject[] target)
        {
            return new TestObject("(" + target[0].GetString() + ")");
        }

        public override string Symbol { get { return "unirary"; } }

        public override int NumberOfParameters {  get { return 1; } }
    }
}

