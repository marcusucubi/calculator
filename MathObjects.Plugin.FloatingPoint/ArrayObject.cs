using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class ArrayObject : IHasOutput, IMathObject, IHasDisplayValue 
    {
        readonly List<IMathObject> list = new List<IMathObject>();

        public ArrayObject(IMathObject[] data)
        {
            this.list = data.ToList();
        }

        public object Output
        {
            get { return this.list.ToArray(); }
        }

        public IMathObject[] Array
        {
            get { return this.list.ToArray(); }
        }

        public string DisplayValue 
        { 
            get { return this.list.ToString(); } 
        }
    }
}

