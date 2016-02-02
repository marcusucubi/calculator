using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopObject : IHasOutput, IMathObject, IHasDisplayValue, IHasName
    {
        readonly IMathObject top;

        readonly string name;

        public TopObject(IMathObject top, string name)
        {
            this.top = top;
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public object Output
        {
            get { return this.top; }
        }

        public string DisplayValue
        {
            get { return "" + this.top.GetDouble(); }
        }

        public override string ToString()
        {
            return "" + top.GetDouble();
        }
    }
}

