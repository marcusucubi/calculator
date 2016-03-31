using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansOperation : AbstractMathOperation
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "radians"; } }

        public override IMathObject Perform(IMathObject[] target)
        {
            if (!target[0].IsDefined())
            {
                var undef = new UndefinedObject();

                undef.SetObjectName(this.Symbol);

                return undef;
            }

            var angle = target[0].GetValue<AngleObject>();
            if (angle != null)
            {
                var result = angle.ConvertToRadians();

                result.CopyDecorations(this);

                result.SetObjectUnit("radians");

                return result;
            }

            var result2 = new AngleObject(
                target[0].GetDouble(), AngleType.Radians);

            result2.CopyDecorations(this);

            result2.SetObjectUnit("radians");

            return result2;
        }
    }
}

