using System;
using MathObjects.Core.Extension;

namespace MathObjects.Framework
{
    public abstract class AbstractMathObject : IMathObject
    {
        readonly ExtensionCollection collection = new ExtensionCollection();

        public ExtensionCollection ExtensionCollection
        {
            get { return collection; }
        }
    }
}

