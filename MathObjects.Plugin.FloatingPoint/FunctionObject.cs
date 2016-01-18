using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    abstract class FunctionObject : IHasOutput, IMathObject, IHasDisplayValue 
    {
        IMathObject result;

        public FunctionObject(ArrayObject arrayObject)
        {
            result = GetResult(arrayObject);
        }

        public object Output
        {
            get { return result; }
        }

        public string DisplayValue
        {
            get { return (result as IHasDisplayValue).DisplayValue; }
        }

        protected abstract IMathObject GetResult(ArrayObject arrayObject);
    }
}

