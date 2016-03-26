using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class MathValue : AbstractMathObject, IMathValue
    {
        public static implicit operator double(MathValue d)
        {
            return d.value;
        }

        readonly double value;

        public MathValue(double value)
        {
            this.value = value;
        }

        public object Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            return "" + value;
        }
    }
}

