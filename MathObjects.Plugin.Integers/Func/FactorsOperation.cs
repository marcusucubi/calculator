using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.Integers.Func
{
    class FactorsOperation : IMathOperation 
    {
        public int NumberOfParameters { get { return 1; } }

        public string Symbol { get { return "factors"; } }

        public IMathObject Perform(IMathObject[] input)
        {
            var leftValue = input[0].GetInteger();

            var result = new MathObject(leftValue);

            result.CopyDecorations(this);

            return result;
        }
    }
}

