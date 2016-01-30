using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    class SubtractObject : IHasOutput, IMathObject
    {
        readonly int tuple1;

        readonly int tuple2;

        public SubtractObject(int tuple1, int tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public object Output
        {
            get { return (tuple1 - tuple2); }
        }
    }
}

