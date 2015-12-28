using System;
using MathObjects.Framework;
using System.Diagnostics;

namespace MathObjects.Plugin.Rational
{
    class InverseObject : IMathObject, IHasTuple, IHasDisplayValue
    {
        readonly IHasTuple target;

        public InverseObject(IHasTuple value)
        {
            if (value == null)
            {
                throw new Exception();
            }
            this.target = value;
        }

        public Tuple<int, int> Tuple
        {
            get 
            { 
                return new Tuple<int, int>(
                    this.target.Tuple.Item2, 
                    this.target.Tuple.Item1); 
            }
        }

        public string DisplayValue
        {
            get { return Tuple.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

