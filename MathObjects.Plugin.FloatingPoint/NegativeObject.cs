using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "-")]
    class NegativeObject : DecoratableObject, IHasOutput, IMathObject, IHasDisplayValue
    {
        readonly double tuple1;

        public NegativeObject(double tuple1)
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

