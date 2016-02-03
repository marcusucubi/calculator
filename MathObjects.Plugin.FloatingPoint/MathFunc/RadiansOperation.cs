using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();
            if (angle != null)
            {
                var result = angle.ConvertToRadians();

                result.CopyDecorations(this);

                return result;
            }

            var result2 = new AngleObject(
                target[0].GetDouble(), AngleType.Radians);

            result2.CopyDecorations(this);

            return result2;
        }
    }
}

