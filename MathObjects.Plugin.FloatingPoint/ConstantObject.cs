using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class ConstantObject : IHasOutput, IMathFunction, IHasDisplayValue
    {
        readonly double value;

        public ConstantObject(double value)
        {
            this.value = value;
        }

        public object Output
        {
            get { return this; }
        }

        public string DisplayValue 
        { 
            get { return "" + this.value; } 
        }

        public void Init(IMathFunctionContext context)
        {
        }

        public void Perform(IMathFunctionContext context)
        {
        }
    }
}

