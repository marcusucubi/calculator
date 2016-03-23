using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "degrees"; } }

        public override IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();
            if (angle != null)
            {
                var result = angle.ConvertToDegrees();

                result.CopyDecorations(this);

                return result;
            }

            var result2 = new AngleObject(
                target[0].GetDouble(), AngleType.Degrees);

            result2.CopyDecorations(this);

            return result2;
        }
    }
}

