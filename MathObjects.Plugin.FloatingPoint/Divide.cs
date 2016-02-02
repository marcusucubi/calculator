using System;
using MathObjects.Framework;
using MathObjects.Core.DecoratableObject;

namespace MathObjects.Plugin.FloatingPoint
{
    [Description(typeof(IHasName), "/")]
    public class Divide : DecoratableObject,
        IMathOperation, IHasName
    {
        public int NumberOfParameters { get { return 2; } }

        public string Name
        {
            get { return "/"; }
        }

        public IMathObject Perform(IMathObject[] objs)
        {
            var leftValue = objs[0].GetDouble();
            var rightValue = objs[1].GetDouble();

            return new DivideObject(leftValue, rightValue);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "/"; }
            }

            public IMathOperation Create(object parm)
            {
                return new Divide();
            }
        }
    }
}

