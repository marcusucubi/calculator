using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public class DecoratableObject : ICanDecorate
    {
        readonly Dictionary<string, object> decorationMap = 
            new Dictionary<string, object>();

        readonly object target;

        public DecoratableObject(object target)
        {
            this.target = target;
        }

        public object Target
        {
            get { return this.target; }
        }

        public IDictionary<string, object> DecorationMap 
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

