using System;

namespace MathObjects.Plugin.FloatingPoint
{
    public class DivideObject
    {
        readonly double tuple1;

        readonly double tuple2;

        public DivideObject(double tuple1, double tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public double Output
        {
            get { return (tuple1 / tuple2); }
        }
    }
}

