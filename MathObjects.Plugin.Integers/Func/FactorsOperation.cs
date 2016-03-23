using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers.Func
{
    class FactorsOperation : AbstractMathOperation 
    {
        public override int NumberOfParameters { get { return 1; } }

        public override string Symbol { get { return "factors"; } }

        public override IMathObject Perform(IMathObject[] input)
        {
            var leftValue = input[0].GetInteger();

            var result = new MathObject(leftValue);

            result.CopyDecorations(this);

            return result;
        }
    }
}

