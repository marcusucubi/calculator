using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "^")]
    public class ExponentOperation : DecoratableObject,
        IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();

            var rightValue = objs[1].GetDouble();

            return new ExponentObject(leftValue, rightValue);
        }
    }
}

