using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopObject : IHasOutput, IMathObject, IHasDisplayValue
    {
        readonly IMathObject top;

        public TopObject(IMathObject top)
        {
            this.top = top;
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

