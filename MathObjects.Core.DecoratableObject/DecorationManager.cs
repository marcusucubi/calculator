using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public static T GetObjectDecoration<T>(this object target, string key)
        {
            object obj = Unproxy(target);

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
            object obj = Unproxy(target);

            DecoratableObject decorable = null;

            if (!dictionary.ContainsKey(obj))
            {
                decorable = new DecoratableObject(obj);

                dictionary[obj] = decorable;
            }
            else
            {
                decorable = dictionary[obj];
            }

            decorable.DecorationMap[key] = value;
        }

        public static void CopyDecorations(this object targetObj, object sourceObj)
        {
            object source = Unproxy(sourceObj);
            object target = Unproxy(targetObj);

            if (!dictionary.ContainsKey(source))
            {
                return;
            }

            var decoratable = dictionary[source].Target as DecoratableObject;

            if (decoratable == null)
            {
                dictionary.Remove(source);
            }
            else
            {
                foreach (var pair in decoratable.DecorationMap)
                {
                    target.SetObjectDecoration(pair.Key, pair.Value);
                }
            }
        }

        static object Unproxy(object target)
        {
            object obj = target;

            var proxy = target as IDecorationProxy;
            if (proxy != null)
            {
                obj = proxy.DecorationTarget;
            }

            return obj;
        }
    }
}

