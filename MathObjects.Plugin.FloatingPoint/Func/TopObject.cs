using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class TopObject : AbstractMathObject, IHasOutput, IHasDisplayValue
    {
        readonly IMathObject top;

        public TopObject(IMathObject top)
        {
            this.top = top;
        }

        public IMathObject Output
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

