using System;

namespace MathObjects.Core.DecoratableObject
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(Type type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        public Type Type { get; protected set; }

        public string Value { get; protected set; }
    }
}

