using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Subtract : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Symbol { get { return "-"; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            return new SubtractObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Subtract();
            }
        }
    }
}
  