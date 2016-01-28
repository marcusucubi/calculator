using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestUniraryOperation : IMathOperation 
    {
        public IMathObject Perform(IMathObject target)
        {
            return new TestObject("(" + target.GetString() + ")");
        }

        public int NumberOfParameters 
        { 
            get { return 1; } 
        }
    }
}

