using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers
{
    class Multiplication : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = (left as IHasValue).Value;
            var rightValue = (right as IHasValue).Value;

            return new MathObject((int)leftValue * (int)rightValue);
        }

        public class Factory : IMathOperationFactory, IMathOperationMeta
        {
            public string Name
            {
                get { return "Multiply"; }
            }

            public IBinaryOperation Create(object parm)
            {
                return new Multiplication();
            }
        }
    }
}

