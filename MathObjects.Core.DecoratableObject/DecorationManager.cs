using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public static class DecorationManager
    {
        readonly static Dictionary<object, DecoratableObject> dictionary
            = new Dictionary<object, DecoratableObject>();

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
            if (!dictionary.ContainsKey(obj))
            {
                return default(T);
            }

            object result = null;

            var decoratable = dictionary[obj];
            if (decoratable != null)
            {
                if (decoratable.DecorationMap.ContainsKey(key))
                {
                    result = decoratable.DecorationMap[key];
                }
            }

            return (T)result;
        }

        public static void SetObjectDecoration(this object target, string key, object value)
        {
            DecoratableObject decorable = null;

            if (!dictionary.ContainsKey(target))
            {
                decorable = new DecoratableObject(target);

                dictionary[target] = decorable;
            }
            else
            {
                decorable = dictionary[target];
            }

            decorable.DecorationMap[key] = value;
        }

        public static void CopyDecorations(this object target, object source)
        {
            if (!dictionary.ContainsKey(source))
            {
                return;
            }

            var decoratable = dictionary[source];

            foreach (var pair in decoratable.DecorationMap)
            {
                target.SetObjectDecoration(pair.Key, pair.Value);
            }
        }
    }
}

