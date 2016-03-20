using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class ExponentOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Symbol { get { return "^"; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new ExponentObject(leftValue, rightValue);
        }
    }
}

