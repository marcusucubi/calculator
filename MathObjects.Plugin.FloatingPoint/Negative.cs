using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Negative : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject left)
        {
            var leftValue = left.GetDouble();

            var op = new NegativeObject(leftValue);

            return new MathObject((double)op.Output);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Negative"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Negative();
            }
        }
    }
}

