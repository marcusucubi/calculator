using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class Negative : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject[] left)
        {
            var leftValue = left[0].GetInteger();

            return new NegativeObject(leftValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Negative();
            }
        }
    }
}

