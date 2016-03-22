using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers.Func
{
    class TopObject : AbstractMathObject, IHasOutput, IHasDisplayValue
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
            get { return "" + this.top.GetInteger(); }
        }

        public override string ToString()
        {
            return "" + top.GetInteger();
        }
    }
}

