using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject target)
        {
            var angle = target.GetValue<AngleObject>();
            if (angle != null)
            {
                return angle.ConvertToDegrees();
            }

            return new AngleObject(target.GetDouble(), AngleType.Degrees);
        }
    }
}

