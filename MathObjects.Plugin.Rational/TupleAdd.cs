using System;

namespace MathObjects.Plugin.Rational
{
    public class TupleAdd
    {
        readonly Tuple<int, int> tuple1;

        readonly Tuple<int, int> tuple2;

        public TupleAdd(Tuple<int, int> tuple1, Tuple<int, int> tuple2)
        {
            this.tuple1 = tuple1;
            this.tuple2 = tuple2;
        }

        public Tuple<int, int> Output
        {
            get
            {
                int value1 = (tuple1.Item1 * tuple2.Item2 +
                              tuple2.Item1 * tuple1.Item2);

                int value2 = tuple1.Item2 * tuple2.Item2;

                var temp = new Tuple<int, int>(value1, value2);

                return new TupleReduce(temp).Output;
            }
        }
    }
}

