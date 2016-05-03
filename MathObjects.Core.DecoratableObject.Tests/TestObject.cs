using System;
using MathObjects.Core.Extension;

namespace MathObjects.Core.DecoratableObject.Tests
{
    [ClassDecoration("name", "TestName")]
    public class TestObject : IExtensionableObject
    {
        readonly ExtensionCollection collection = new ExtensionCollection();

        public ExtensionCollection ExtensionCollection
        {
            get { return collection; }
        }
    }
}

