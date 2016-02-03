using System;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public class DecoratableObject : ICanDecorate
    {
        readonly Dictionary<string, object> decorationMap = 
            new Dictionary<string, object>();

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

