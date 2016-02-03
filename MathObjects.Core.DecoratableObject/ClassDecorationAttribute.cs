using System;

namespace MathObjects.Core.DecoratableObject
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassDecorationAttribute : Attribute
    {
        public ClassDecorationAttribute(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get; protected set; }

        public object Value { get; protected set; }
    }
}

