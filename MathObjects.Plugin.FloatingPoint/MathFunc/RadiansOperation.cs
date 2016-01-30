using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject target)
        {
            var angle = target.GetValue<AngleObject>();
            if (angle != null)
            {
                return angle.ConvertToRadians();
            }

            return new AngleObject(target.GetDouble(), AngleType.Radians);
        }
    }
}

