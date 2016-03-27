using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers
{
    public class Negative : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "-"; } }

        public override IMathObject Perform(IMathObject[] left)
        {
            if (!left[0].IsDefined())
            {
                return new UndefinedObject();
            }

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

