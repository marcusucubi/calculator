using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    class Add : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "add"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            if (!objs[0].IsDefined() || !objs[1].IsDefined())
            {
                return new UndefinedObject();
            }

            var leftValue = objs[0].GetTuple();
            var rightValue = objs[1].GetTuple();

            return new AddObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Add"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Add();
            }
        }
    }
}

