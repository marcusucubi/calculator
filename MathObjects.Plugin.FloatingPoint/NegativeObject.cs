using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class NegativeObject : IHasOutput, IMathObject
    {
        readonly double tuple1;

        public NegativeObject(double tuple1)
        {
            this.tuple1 = tuple1;
        }

        public object Output
        {
            get { return (-tuple1); }
        }
    }
}

