using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers
{
    public class ExponentOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "^"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            if (!objs[0].IsDefined() || !objs[1].IsDefined())
            {
                return new UndefinedObject();
            }

            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new ExponentObject(leftValue, rightValue);
        }
    }
}

