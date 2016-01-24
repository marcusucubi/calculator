using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Rational
{
    class Inverse : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject target)
        {
            var tuple = target.GetTuple();
            if (tuple != null)
            {
                return new InverseObject(tuple);
            }

            throw new Exception();
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Inverse"; }
            }

            public IMathOperation Create(object param)
            {
                return new Inverse();
            }
        }
    }
}

