using System;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestValue : AbstractMathObject, IMathValue
    {
        readonly string value;

        public TestValue(string value)
        {
            this.value = value;
        }

        public object Value
        {
            get { return this.value; }
        }

        public bool IsDefinded 
        { 
            get { return true; } 
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}

