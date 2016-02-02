using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class RadiansOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public string Name
        {
            get { return "radians"; }
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();
            if (angle != null)
            {
                return angle.ConvertToRadians();
            }

            return new AngleObject(
                target[0].GetDouble(), AngleType.Radians, this.Name);
        }
    }
}

