using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    class Add : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "+"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            return new AddObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Add();
            }
        }
    }
}

