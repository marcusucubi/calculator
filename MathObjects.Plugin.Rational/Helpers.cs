using System;
using System.Linq;

namespace MathObjects.Plugin.Rational
{
    public static class Helpers
    {
        static public int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static public int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}

