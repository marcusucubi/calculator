using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    class DecoratableObject 
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

        public void CopyDecorations(DecoratableObject decorate)
        {
            foreach (var pair in decorate.DecorationMap)
            {
                this.decorationMap.Add(pair.Key, pair.Value);
            }
        }
    }
}

