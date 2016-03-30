using System;
using MathObjects.Core.Extension;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Framework
{
    public static class NameManager
    {
        public static string GetObjectName(this IExtensionableObject target)
        {
            return target.GetObjectDecoration<string>("name");
        }

        public static void SetObjectName(this IExtensionableObject target, string name)
        {
            target.SetObjectDecoration("name", name);
        }
    }
}

