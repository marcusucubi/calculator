using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers.Func
{
    class FactorsOperation : IMathOperation 
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject[] input)
        {
            var leftValue = input[0].GetInteger();

            return new MathObject(leftValue);
        }
    }
}

