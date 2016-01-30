using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    class NegativeObject : IHasOutput, IMathObject
    {
        readonly int tuple1;

        public NegativeObject(int tuple1)
        {
            this.tuple1 = tuple1;
        }

        public object Output
        {
            get { return (-tuple1); }
        }
    }
}

