using System;
using MathObjects.Core.Extension;

namespace MathObjects.Core.DecoratableObject.Tests
{
    public class TestObject2 : IExtensionableObject
    {
        readonly ExtensionCollection collection = new ExtensionCollection();

        public ExtensionCollection ExtensionCollection
        {
            get { return collection; }
        }
    }
}

