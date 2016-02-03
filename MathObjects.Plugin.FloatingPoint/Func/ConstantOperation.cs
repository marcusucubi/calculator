using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantOperation : IMathOperation
    {
        readonly double value;

        public int NumberOfParameters { get { return 0; } }

        public ConstantOperation(double value)
        {
            this.value = value;
        }

        public IMathObject Perform(IMathObject[] target)
        {
            var result = new ConstantObject(value);

            result.CopyDecorations(this);

            return result;
        }
    }
}

