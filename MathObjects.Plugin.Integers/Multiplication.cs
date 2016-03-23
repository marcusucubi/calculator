using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Multiplication : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "*"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetInteger();
            var rightValue = objs[1].GetInteger();

            return new MultiplyObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Multiplication();
            }
        }
    }
}

