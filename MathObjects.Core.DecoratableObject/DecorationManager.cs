using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public static class DecorationManager
    {
        public static Dictionary<Type, object> GetAttributes(Type input)
        {
            var result = new Dictionary<Type, object>();

            object[] objs = input.GetCustomAttributes(false);
            foreach (var obj in objs)
            {
                var desc = obj as DescriptionAttribute;
                if (desc != null)
                {
                    result[desc.Type] = desc.Value;
                }
            }

            return result;
        }

        public static object GetDescription<T>(this object obj)
        {
            var map = GetAttributes(obj.GetType());

            if (map.ContainsKey(typeof(T)))
            {
                return map[typeof(T)];
            }

            return null;
        }
    }
}

