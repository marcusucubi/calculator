using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    public class Multiply : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "*"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            if (!objs[0].IsDefined() || !objs[1].IsDefined())
            {
                return new UndefinedObject();
            }

            var leftValue = objs[0].GetTuple();
            var rightValue = objs[1].GetTuple();

            return new MultiplyObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Multiply"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Multiply();
            }
        }
    }
}

