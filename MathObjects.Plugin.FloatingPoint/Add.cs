using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class Add : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 2; } }

        public override string Symbol { get { return "+"; } }

        public override IMathObject Perform(IMathObject[] objs)
        {
            if (!objs[0].IsDefined() || !objs[1].IsDefined())
            {
                var result = new UndefinedObject();

                result.SetObjectName("+");

                return result;
            }

            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            var addObj = new AddObject(leftValue, rightValue);

            addObj.CopyDecorations(objs[0]);
            addObj.CopyDecorations(objs[1]);

            return addObj;
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

