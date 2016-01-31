using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ExponentOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Name
        {
            get { return "^"; }
        }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();

            var rightValue = objs[1].GetDouble();

            var op = new ExponentObject(leftValue, rightValue);

            return new MathObject((double)op.Output);
        }
    }
}

