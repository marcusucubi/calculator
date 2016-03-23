using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class ExponentOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "^"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new ExponentObject(leftValue, rightValue);
        }
    }
}

