using System;
using System.Collections.Generic;

namespace MathObjects.Framework.Parser
{
    public class MathScope : IMathScope
    {
        readonly IDictionary<string, IMathObject> map = new Dictionary<string, IMathObject>();

        public IMathObject Get(string name)
        {
            if (!map.ContainsKey(name))
            {
                return new UndefinedObject();
            }

            return map[name];
        }

        public void Put(string name, IMathObject obj)
        {
            this.map[name] = obj;
        }
    }
}

