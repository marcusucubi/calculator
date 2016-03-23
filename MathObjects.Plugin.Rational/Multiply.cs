using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Rational
{
    public class Multiply : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "*"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetTuple();
            var rightValue = objs[1].GetTuple();

            var op = new MultiplyObject(leftValue, rightValue);

            return new MathObject(op.Output as Tuple<int, int>);
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

