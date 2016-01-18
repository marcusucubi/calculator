using System;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Gcd : IMathBinaryOperation
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
            var leftValue = GetValue(left);
            var rightValue = GetValue(right);

            return new MathObject("" + GCD(leftValue, rightValue));
        }

        int GetValue(IMathObject obj)
        {
            var hasValue = obj as IHasValue;
            if (hasValue != null)
            {
                return hasValue.Value;
            }

            var hasOutput = obj as IHasOutput;
            if (hasOutput != null)
            {
                var has2 = hasOutput.Output as IHasValue;
                return has2.Value;
            }

            throw new Exception();
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "GCD"; }
            }

            public IMathBinaryOperation Create(object parm)
            {
                return new Gcd();
            }
        }
    }
}

