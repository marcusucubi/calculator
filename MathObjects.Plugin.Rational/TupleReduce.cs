using System;

namespace MathObjects.Plugin.Rational
{
    public class TupleReduce
    {
        readonly Tuple<int, int> tuple;

        public TupleReduce(Tuple<int, int> tuple)
        {
            this.tuple = tuple;
        }

        public Tuple<int, int> Output
        {
            get
            {
                int gcd = Helpers.GCD(tuple.Item1, tuple.Item2);

                return new Tuple<int, int>(
                    tuple.Item1 / gcd, tuple.Item2 / gcd);
            }
        }
    }
}

