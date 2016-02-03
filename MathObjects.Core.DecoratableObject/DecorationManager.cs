using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public static class DecorationManager
    {
        public static T GetClassDecoration<T>(this object obj, string key)
        {
            return GetClassDecoration<T>(obj.GetType(), key);
        }

        public static T GetClassDecoration<T>(Type input, string key)
        {
            object result = null;

            object[] objs = input.GetCustomAttributes(false);
            foreach (var obj in objs)
            {
                var desc = obj as ClassDecorationAttribute;
                if (desc != null && desc.Key == key)
                {
                    result = desc.Value;
                    break;
                }
            }

            return (T)result;
        }

        public static T GetObjectDecoration<T>(this object obj, string key)
        {
            object result = null;

            var decoratable = obj as ICanDecorate;
            if (decoratable != null)
            {
                if (decoratable.DecorationMap.ContainsKey(key))
                {
                    result = decoratable.DecorationMap[key];
                }
            }

            return (T)result;
        }

        public static void SetObjectDecoration(
            this object target, string key, object value)
        {
            var decoratable = target as ICanDecorate;
            if (decoratable != null)
            {
                decoratable.DecorationMap[key] = value;
            }
        }
    }
}

