using System;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Gcd : IBinaryOperation
    {
        static public int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static public int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = (int) (left as IHasValue).Value;
            var rightValue = (int) (right as IHasValue).Value;

            return new MathObject("" + GCD(leftValue, rightValue));
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "GCD"; }
            }

            public IBinaryOperation Create(object parm)
            {
                return new Gcd();
            }
        }
    }
}

