using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class ConstantObject : 
        IHasOutput, IMathObject, IHasDisplayValue
    {
        readonly double value;

        public ConstantObject(double value)
        {
            this.value = value;
        }

        public object Output
        {
            get { return new MathObject(value); }
        }

        public string DisplayValue 
        { 
            get { return "" + this.value; } 
        }
    }
}

