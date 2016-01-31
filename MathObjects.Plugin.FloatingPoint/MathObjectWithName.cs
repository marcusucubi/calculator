using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class MathObjectWithName : 
        IMathObject, IHasOutput, IHasDisplayValue, IHasName 
    {
        readonly double value;

        readonly string name;

        public MathObjectWithName(double param, string name)
        {
            this.value = param;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public object Output
        {
            get { return this.value; }
        }

        public string DisplayValue 
        { 
            get { return this.value.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

