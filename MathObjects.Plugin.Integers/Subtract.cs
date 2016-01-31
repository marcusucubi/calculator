using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class Subtract : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            var op = new SubtractObject(leftValue, rightValue);

            return new MathObject((int)op.Output);
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
  