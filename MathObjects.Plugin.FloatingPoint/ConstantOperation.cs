using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class ConstantOperation : IMathOperation
    {
        readonly double value;

        public int NumberOfParameters { get { return 0; } }

        public ConstantOperation(double value)
        {
            this.value = value;
        }

        public IMathObject Perform(IMathObject target)
        {
            return new MathObject(value);
        }
    }
}

