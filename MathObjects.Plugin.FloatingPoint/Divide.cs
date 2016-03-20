using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [ClassDecoration("name", "/")]
    public class Divide : IMathOperation
    {
        public int NumberOfParameters { get { return 2; } }

        public string Symbol { get { return "/"; } }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            return new DivideObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory
        {
            public IMathOperation Create(object parm)
            {
                return new Divide();
            }
        }
    }
}

