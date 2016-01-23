using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class CosineObject : IMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double target;

        public CosineObject(double value)
        {
            this.target = Math.Cos(value);
        }

        public object Output
        {
            get { return this.target; }
        }

        public string DisplayValue
        {
            get { return Output.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

