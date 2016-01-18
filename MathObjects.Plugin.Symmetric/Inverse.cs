using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Symmetric
{
    class Inverse : IMathOperation
    {
        public IMathObject Perform(IMathObject target)
        {
            var hasMatrix = target as IHasMatrix;
            if (hasMatrix != null)
            {
                return new InverseObject(hasMatrix);
            }

            var hasOutput = target as IHasOutput;
            if (hasOutput != null)
            {
                return new InverseObject(hasOutput.Output as IHasMatrix);
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

