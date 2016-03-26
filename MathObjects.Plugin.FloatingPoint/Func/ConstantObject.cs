using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double value;

        public ConstantObject(double value)
        {
            this.value = value;
        }

        public IMathObject Output
        {
            get { return new MathObject(value); }
        }

        public string DisplayValue 
        { 
            get { return "" + this.value; } 
        }
    }
}

