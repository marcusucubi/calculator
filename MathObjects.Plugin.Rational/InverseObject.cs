using System;
using MathObjects.Framework;
using System.Diagnostics;

namespace MathObjects.Plugin.Rational
{
    class InverseObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly Tuple<int, int> target;

        public InverseObject(Tuple<int, int> value)
        {
            if (value == null)
            {
                throw new Exception();
            }

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

