using System;
using MathObjects.Core.Extension;
using System.Collections.Generic;

namespace MathObjects.Core.DecoratableObject
{
    public class DecoratableExtension : IExtension
    {
        readonly Dictionary<string, object> map = new Dictionary<string, object>();

        public Dictionary<string, object> Map
        {
            get { return this.map; }
        }

        public override string ToString()
        {
            return this.map.ToString();
        }
    }
}

