using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class TopFunction : FunctionObject
    {
        public TopFunction(ArrayObject arrayObject)
            : base(arrayObject)
        {
        }

        protected override IMathObject GetResult(ArrayObject arrayObject)
        {
            return new ConstantObject(Math.PI);
        }
    }
}

