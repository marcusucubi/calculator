using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public static class MathObjectEx
    {
        public static int GetInteger(this IMathObject obj)
        {
            return obj.GetValue<int>();
        }
    }
}

