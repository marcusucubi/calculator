using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint.Func
{
    class ConstantOperation : AbstractMathOperation
    {
        readonly double value;

        public override int NumberOfParameters { get { return 0; } }

        public override string Symbol { get { return "const"; } }

        public ConstantOperation(double value)
        {
            this.value = value;
        }

        public override IMathObject Perform(IMathObject[] target)
        {
            var result = new ConstantObject(value);

            result.CopyDecorations(this);

            return result;
        }
    }
}

