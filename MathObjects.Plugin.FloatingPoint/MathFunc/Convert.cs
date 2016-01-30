using System;

namespace MathObjects.Plugin.FloatingPoint.MathFunc
{
    public static class Convert
    {
        public static double RadiansToDegrees(double radians)
        {
            return (radians / Math.PI) * 180;
        }

        public static double DegreesToRadians(double angle)
        {
            return (angle / 180) * Math.PI;
        }
    }
}

