using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class RandomObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double value;

        public RandomObject(double value)
        {
            this.value = value;
        }

        public IMathObject Output
        {
            get { return new MathObject(value); }
        }

        public string DisplayValue 
        { 
			get { return "random object(" + this.value + ")"; } 
        }

        public override string ToString()
        {
            return "random object(" + DisplayValue + ")";
        }
    }
}

