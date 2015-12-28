using System;

namespace MathObjects.Plugin.Rational
{
    public class Tuple
    {
        readonly int value1;

        readonly int value2;

        public Tuple(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public int Value1
        {
            get { return this.value1; }
        }

        public int Value2
        {
            get { return this.value2; }
        }
    }
}

