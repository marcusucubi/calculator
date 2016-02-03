using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantObject : 
        DecoratableObject, IHasOutput, IMathObject, IHasDisplayValue, IHasName 
    {
        readonly double value;

        readonly string name;

        public ConstantObject(double value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public object Output
        {
            get { return new MathObject(value); }
        }

        public string DisplayValue 
        { 
            get { return "" + this.value; } 
        }
    }
}

