using System;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class Convert
    {
        public static double RadiansToAngle(double radians)
        {
            return (radians / Math.PI) * 180;
        }

        public static double AngleToRadians(double angle)
        {
            return (angle / 180) * Math.PI;
        }
    }
}

