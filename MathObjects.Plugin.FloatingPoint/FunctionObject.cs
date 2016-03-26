using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class FunctionObject : AbstractMathObject, IHasOutput, IHasDisplayValue, IHasValue
    {
        readonly IMathObject result;

        public FunctionObject(IMathObject result)
        {
            this.result = result;
        }

        public IMathObject Output
        {
            get { return result; }
        }

        public IMathValue Value 
        { 
            get 
            {
                var hasValue = result as IHasValue;
                if (hasValue != null)
                {
                    return hasValue.Value;
                }

                return null; 
            }
        }

        public string DisplayValue
        {
            get 
            { 
                var display = result as IHasDisplayValue;
                if (display != null)
                {
                    return display.DisplayValue;
                }

                var output = result as IHasOutput;
                if (output != null)
                {
                    return "" + output.Output;
                }

                return "" + result; 
            }
        }
    }
}

