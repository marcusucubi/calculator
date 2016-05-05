using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;

namespace MathObjects.Framework.Parser
{
    class StackParamObject : AbstractMathObject, 
        IHasOutput, IHasDisplayValue
    {
        readonly IMathObject value;

        public StackParamObject(IMathObject value)
        {
            var canCopy = value as ICanCopyByValue;
            if (canCopy != null)
            {
                this.value = canCopy.CopyByValue();
            }
            else
            {
                this.value = value;
            }
        }

        public IMathObject Output
        {
            get { return value; }
        }

        public string DisplayValue 
        { 
            get { return "" + this.value; } 
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}


