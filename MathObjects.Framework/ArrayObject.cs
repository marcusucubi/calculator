using System;
using System.Linq;
using System.Collections.Generic;
using MathObjects.Framework;

namespace MathObjects.Framework
{
    public class ArrayObject : AbstractMathObject, IHasDisplayValue //, IHasOutput 
    {
        readonly List<IMathObject> list = new List<IMathObject>();

        public ArrayObject()
        {
        }

        public ArrayObject(IMathObject[] data)
        {
            this.list = data.ToList();
        }

        public IMathObject this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

//        public IMathObject Output
//        {
//            get { return this.list.ToArray(); }
//        }

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

