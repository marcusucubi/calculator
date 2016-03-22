using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers
{
    [ClassDecoration("name", "-")]
    class NegativeObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly int tuple1;

        public NegativeObject(int tuple1)
        {
            this.tuple1 = tuple1;
        }

        public object Output
        {
            get { return (-tuple1); }
        }

        public string DisplayValue 
        { 
            get { return this.Output.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

