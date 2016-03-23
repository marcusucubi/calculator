using System;
using MathObjects.Core.Extension;

namespace MathObjects.Framework
{
    public abstract class AbstractMathOperation : IMathOperation
    {
        readonly ExtensionCollection collection = new ExtensionCollection();

        public abstract IMathObject Perform(IMathObject[] target);

        public abstract int NumberOfParameters { get; }

        public abstract string Symbol { get; }

        public ExtensionCollection ExtensionCollection
        {
            get { return collection; }
        }
    }
}

