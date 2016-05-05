using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Multiply : AbstractMathOperation, IHasName
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "*"; } }

        public string Name { get { return "*"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            if (!objs[0].IsDefined() || !objs[1].IsDefined())
            {
                if (!objs[0].IsDefined() || !objs[1].IsDefined())
                {
                    var result = new UndefinedObject();

                    result.SetObjectName("*");

                    return result;
                }
            }

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

