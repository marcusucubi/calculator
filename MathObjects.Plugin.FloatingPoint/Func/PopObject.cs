using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    class PopObject : AbstractMathObject, 
        IHasOutput, IHasDisplayValue, ICanCopyByValue, IHasChildren 
    {
        readonly IMathObject top;

        public PopObject(IMathObject obj)
        {
            this.top = obj;
        }

        public IMathObject Output
        {
            get { return this.top; }
        }

        public string DisplayValue
        {
            get 
            {
                var display = this.top as IHasDisplayValue;
                if (display != null)
                {
                    return display.DisplayValue;
                }

                return "" + this.top.GetDouble(); 
            }
        }

        public IMathObject[] Children
        {
            get 
            {
                var parent = this.top as IHasChildren;
                if (parent != null)
                {
                    return parent.Children;
                }
                
                return new IMathObject[] {}; 
            }
        }

        public IMathObject CopyByValue()
        {
            return new PopObject(this.top);
        }

        public override string ToString()
        {
            return this.DisplayValue;
        }
    }
}

