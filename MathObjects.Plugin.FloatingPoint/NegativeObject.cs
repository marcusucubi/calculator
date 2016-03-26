using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "-")]
    class NegativeObject : AbstractMathObject, IHasOutput, IHasDisplayValue, IHasValue
    {
        readonly double tuple1;

        public NegativeObject(double tuple1)
        {
            this.tuple1 = tuple1;
        }

        public IMathObject Output
        {
            get { return new MathObject(-tuple1); }
        }

        public IMathValue Value 
        { 
            get { return new MathValue(-tuple1); } 
        }

        public string DisplayValue 
        { 
            get { return "" + (-tuple1); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

