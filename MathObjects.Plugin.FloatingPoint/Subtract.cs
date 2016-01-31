using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Subtract : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            var op = new SubtractObject(leftValue, rightValue);

            return new MathObject((double)op.Output);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "-"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Subtract();
            }
        }
    }
}
  