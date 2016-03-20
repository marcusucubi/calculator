using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    public class Multiply : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Symbol { get { return "*"; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new MultiplyObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Multiply();
            }
        }
    }
}

