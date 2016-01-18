using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    public static class MathObjectEx
    {
        public static Tuple<int, int> GetTuple(this IMathObject obj)
        {
            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var output = hasOutput.Output;
                if (output is Tuple<int, int>)
                {
                    return (Tuple<int, int>)output;
                }

                var has2 = hasOutput.Output as IHasOutput;
                return (Tuple<int, int>)has2.Output;
            }

            throw new Exception();
        }

        public static Tuple<int, int> GetInverse(this Tuple<int, int> obj)
        {
            return new Tuple<int, int>(obj.Item2, obj.Item1);
        }
    }
}

