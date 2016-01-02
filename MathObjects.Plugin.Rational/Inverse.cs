using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Rational
{
    class Inverse : IMathOperation
    {
        public IMathObject Perform(IMathObject target)
        {
            var hasTuple = target as IHasTuple;
            if (hasTuple != null)
            {
                return new InverseObject(hasTuple);
            }

            var hasOutput = target as IHasOutput;
            if (hasOutput != null)
            {
                return new InverseObject(hasOutput.Output as IHasTuple);
            }

            throw new Exception();
        }

        public class Factory : IMathOperationFactory2, IHasName
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

