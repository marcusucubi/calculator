using System;
using MathObjects.Core.Extension;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework
{
    public static class UnitManager
    {
        public static string GetObjectUnit(this IExtensionableObject target)
        {
            return target.GetObjectDecoration<string>("unit");
        }

        public static void SetObjectUnit(this IExtensionableObject target, string name)
        {
            target.SetObjectDecoration("unit", name);
        }
    }
}

