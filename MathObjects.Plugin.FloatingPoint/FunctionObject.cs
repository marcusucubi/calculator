using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    abstract class FunctionObject : IHasOutput, IMathFunction, IHasDisplayValue 
    {
        IMathObject result;

        public object Output
        {
            get { return result; }
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

        public void Perform(IMathFunctionContext context)
        {
            result = InternalGetResult(context);
        }
        
        protected abstract IMathObject InternalGetResult(IMathFunctionContext context);
    }
}

