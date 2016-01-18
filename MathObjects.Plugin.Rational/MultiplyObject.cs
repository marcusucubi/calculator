using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    class MultiplyObject : IHasOutput, IMathObject
    {
        readonly Tuple<int, int> result;

        public MultiplyObject(
            Tuple<int, int> tuple1, 
            Tuple<int, int> tuple2)
        {
            result = new Tuple<int, int>(
                tuple1.Item1 * tuple2.Item1,
                tuple1.Item2 * tuple2.Item2);
            
            result = new TupleReduce(result).Output;
        }

        public object Output
        {
            get { return result; }
        }
    }
}

