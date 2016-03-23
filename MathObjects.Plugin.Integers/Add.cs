using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Add : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "+"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new AddObject(leftValue, rightValue);
        }
    }
}

