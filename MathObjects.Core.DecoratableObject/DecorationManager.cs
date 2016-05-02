using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathObjects.Core.Extension;

namespace MathObjects.Core.DecoratableObject
{
    public static class DecorationManager
    {
        readonly static string className = typeof(DecoratableExtension).Name;

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

        public static DecoratableExtension GetClassDecorations(Type input)
        {
            var ext = new DecoratableExtension();

            object[] objs = input.GetCustomAttributes(false);
            foreach (var obj in objs)
            {
                var desc = obj as ClassDecorationAttribute;
                if (desc != null)
                {
                    ext.Map[desc.Key] = desc.Value;
                }
            }

            return ext;
        }

        public static T GetObjectDecoration<T>(this IExtensionableObject target, string key)
        {
            var ext = GetExtension(target);

            if (!ext.Map.ContainsKey(key))
            {
                return default(T);
            }

            return (T)ext.Map[key];
        }

        public static void SetObjectDecoration(this IExtensionableObject target, 
            string key, object value)
        {
            var ext = GetExtension(target);

            ext.Map[key] = value;
        }

        public static void CopyDecorations(
            this IExtensionableObject targetObj, 
            IExtensionableObject sourceObj)
        {
            var sourceExt = GetExtension(sourceObj);
            var targetExt = GetExtension(targetObj);

            foreach (var pair in sourceExt.Map)
            {
                targetExt.Map[pair.Key] = pair.Value;
            }

            var ext = GetClassDecorations(sourceObj.GetType());

            foreach (var pair in ext.Map)
            {
                targetExt.Map[pair.Key] = pair.Value;
            }
        }

        static DecoratableExtension GetExtension(object target)
        {
            var obj = target as IExtensionableObject;

            if (obj == null)
            {
                return new DecoratableExtension();
            }

            DecoratableExtension ext = null;

            if (obj.ExtensionCollection.ContainsKey(className))
            {
                ext = obj.ExtensionCollection[className] as DecoratableExtension;
            }
            else
            {
                ext = new DecoratableExtension();
                obj.ExtensionCollection[className] = ext;
            }

            return ext;
        }
    }
}

