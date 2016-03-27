using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestObject : AbstractMathObject, IHasValue 
    {
        readonly string value;

        public TestObject(string value)
        {
            this.value = value;
        }

        public IMathValue Value 
        { 
            get { return new TestValue(this.value); } 
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}

