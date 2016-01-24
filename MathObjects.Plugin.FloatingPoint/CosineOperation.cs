using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    class CosineOperation : IMathOperation
    {
        public int NumberOfParameters { get { return 1; } }

        public IMathObject Perform(IMathObject target)
        {
            return new CosineObject(target.GetDouble());
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Cosine"; }
            }

            public IMathOperation Create(object param)
            {
                return new CosineOperation();
            }
        }
    }
}

