using System;

namespace MathObjects.Framework.Tests
{
    public class TestMathOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 0; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            return new TestMathObject ();
        }

        public string Symbol 
        { 
            get { return "test"; } 
        }
    }
}

