using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "^")]
    public class ExponentOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "^"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();

            var rightValue = objs[1].GetDouble();

            return new ExponentObject(leftValue, rightValue);
        }
    }
}

