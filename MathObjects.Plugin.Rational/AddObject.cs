using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    public class AddObject : AbstractMathObject, IHasOutput, IHasValue 
    {
        readonly Tuple<int, int> result;

        public AddObject(Tuple<int, int> tuple1, Tuple<int, int> tuple2)
        {
            int value1 = (tuple1.Item1 * tuple2.Item2 +
                tuple2.Item1 * tuple1.Item2);

            int value2 = tuple1.Item2 * tuple2.Item2;

            var temp = new Tuple<int, int>(value1, value2);

            this.result = new TupleReduce(temp).Output;
        }

        public IMathValue Value 
        { 
            get { return new MathValue(result); }
        }

        public IMathObject Output
        {
            get { return new MathObject(result); }
        }
    }
}

