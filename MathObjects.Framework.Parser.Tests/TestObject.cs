using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestObject : IMathObject, IHasOutput
    {
        readonly string value;

        public TestObject(string value)
        {
            this.value = value;
        }

        public object Output 
        { 
            get { return value; } 
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}

