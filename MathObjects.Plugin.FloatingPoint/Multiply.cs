using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Multiply : AbstractMathOperation, IHasName
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "*"; } }

        public string Name { get { return "*"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

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

