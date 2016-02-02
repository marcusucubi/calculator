using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public class DecoratableObject : ICanDecorate
    {
        readonly Dictionary<Type, object> decorationMap = 
            new Dictionary<Type, object>();

        public DecoratableObject()
        {
        }

        public void ReadAttributes()
        {
            object[] objs = this.GetType().GetCustomAttributes(false);
            foreach (var obj in objs)
            {
                var desc = obj as DescriptionAttribute;
                if (desc != null)
                {
                    this.DecorationMap[desc.Type] = desc.Value;
                }
            }
        }

        public IDictionary<Type, object> DecorationMap 
        { 
            get { return this.decorationMap; } 
        }

        public void CopyDecorations(ICanDecorate decorate)
        {
            foreach (var pair in decorate.DecorationMap)
            {
                this.decorationMap.Add(pair.Key, pair.Value);
            }
        }
    }
}

