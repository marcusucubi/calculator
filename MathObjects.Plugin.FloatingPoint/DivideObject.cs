using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class DivideObject : IHasOutput
    {
        readonly double tuple1;

        readonly double tuple2;

        public DivideObject(double tuple1, double tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public object Output
        {
            get { return (tuple1 / tuple2); }
        }
    }
}

