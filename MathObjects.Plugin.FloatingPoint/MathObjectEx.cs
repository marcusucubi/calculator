using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    public static class MathObjectEx
    {
        public static double GetDouble(this IMathObject obj)
        {
            return obj.GetValue<double>();
        }
    }
}

