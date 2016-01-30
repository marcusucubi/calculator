using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class AngleObject : IMathObject, IHasOutput, IHasDisplayValue
    {
        readonly double target;

        public AngleObject(double value)
        {
            this.target = value;
        }

        public object Output
        {
            get { return Convert.RadiansToAngle(this.target); }
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

