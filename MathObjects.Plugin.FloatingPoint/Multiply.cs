using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Multiply : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Name
        {
            get { return "*"; }
        }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            var op = new MultiplyObject(leftValue, rightValue);

            return new MathObject((double)op.Output);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "*"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Multiply();
            }
        }
    }
}

