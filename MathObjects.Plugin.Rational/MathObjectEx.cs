using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    public static class MathObjectEx
    {
        public static Tuple<int, int> GetTuple(this IMathObject obj)
        {
            return obj.GetValue<Tuple<int, int>>();
        }

        public static Tuple<int, int> GetInverse(this Tuple<int, int> obj)
        {
            return new Tuple<int, int>(obj.Item2, obj.Item1);
        }
    }
}

