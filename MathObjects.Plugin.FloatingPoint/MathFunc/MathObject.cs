using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class MathObject : IMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double target;

        public MathObject(double value)
        {
            this.target = value;
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

