using System;

namespace MathObjects.Framework.Tests
{
    public class TestMathOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 0; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            return new TestMathObject ();
        }

        public override string Symbol 
        { 
            get { return "test"; } 
        }
    }
}

