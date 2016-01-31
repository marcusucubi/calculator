using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    class DegreesOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public string Name
        {
            get { return "degrees"; }
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var angle = target[0].GetValue<AngleObject>();
            if (angle != null)
            {
                return angle.ConvertToDegrees();
            }

            return new AngleObject(target[0].GetDouble(), AngleType.Degrees);
        }
    }
}

