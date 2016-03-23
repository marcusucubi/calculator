using System;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers.Func
{
    class GcdOperation : AbstractMathOperation 
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "gcd"; } }

        static public int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static public int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public override IMathObject Perform(IMathObject[] input)
        {
            var leftValue = input[0].GetInteger();
            var rightValue = input[1].GetInteger();

            var result = new MathObject(GCD(leftValue, rightValue));

            result.CopyDecorations(this);

            return result;
        }
    }
}

