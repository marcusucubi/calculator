using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser.Tests
{
    public class TestObject : AbstractMathObject
    {
        readonly string value;

        public TestObject(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value;
        }
    }
}

