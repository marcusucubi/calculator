using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    public class MathValue : AbstractMathObject, IMathValue
    {
        readonly Tuple<int, int> tuple;

        public MathValue(Tuple<int, int> tuple)
        {
            this.tuple = tuple;
        }

        public object Value
        {
            get { return this.tuple; }
        }

        public Tuple<int, int> Tuple
        {
            get { return this.tuple; }
        }

        public bool IsDefinded 
        { 
            get { return true; } 
        }
    }
}

