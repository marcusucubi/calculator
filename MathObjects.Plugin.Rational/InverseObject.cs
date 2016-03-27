using System;
using MathObjects.Framework;
using System.Diagnostics;

namespace MathObjects.Plugin.Rational
{
    class InverseObject : AbstractMathObject, IHasOutput, IHasDisplayValue, IHasValue
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

        public IMathObject Output
        {
            get { return new MathObject(this.target); }
        }

        public IMathValue Value 
        { 
            get { return new MathValue(this.target); }
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

